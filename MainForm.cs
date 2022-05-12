using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using FolderCreation.Model;

namespace FolderCreation
{
    public partial class MainForm : Form
    {
        List<Folder> _folderList = new List<Folder>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            baseDirectory.Text = LoadSetting("Base");

            int length = int.Parse(LoadSetting("Display"));

            for (int i=0; i<length;i++)
            {
                CreatePanel(true);
            }
        }

        /// <summary>
        /// アプリ終了時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }

        /// <summary>
        /// ...ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseDirectrySelectBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            // デフォルトルートフォルダ
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult result =  fbd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = fbd.SelectedPath;

                this.baseDirectory.Text = path;
            }
        }

        /// <summary>
        /// 作成ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.baseDirectory.Text))
            {
                MessageBox.Show("ディレクトリを指定してください",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            _folderList.Clear();

            int i = 1;
            Control.ControlCollection controls = this.folderGroup.Controls;
            foreach (Control control in controls)
            {
                if (control.GetType() != typeof(Panel))
                {
                    continue;
                }
                
                Control.ControlCollection panel = control.Controls;
                NumericUpDown numeric = (NumericUpDown)panel[0];
                TextBox name = (TextBox)panel[1];

                Folder folder = new Folder(i, (int)numeric.Value, name.Text);
                folder.Create(baseDirectory.Text);
                _folderList.Add(folder);
                i++;
            }
        }

        /// <summary>
        /// +ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            int controlCount = this.folderGroup.Controls.Count;
            if (controlCount >= int.Parse(LoadSetting("MaxDisplay")))
            {
                return;
            }
            CreatePanel();
        }

        /// <summary>
        /// -ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int controlCount = this.folderGroup.Controls.Count;
            if (controlCount <= 1)
            {
                return;
            }
            RemovePanel();
        }

        /// <summary>
        /// 設定ファイルから値を読み込む
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string LoadSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key]?.Value ?? null;
        }

        /// <summary>
        /// 設定ファイルに値を書き込む
        /// </summary>
        private void SaveSetting()
        {
            // 作成していなければ更新しない
            if (_folderList.Count == 0)
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // ベースディレクトリの保存
            config.AppSettings.Settings["Base"].Value = baseDirectory.Text;

            int length = int.Parse(LoadSetting("MaxDisplay"));

            for (int i = 1; i <= length; i++)
            {
                config.AppSettings.Settings[$"Number{i}"].Value = i.ToString();
                config.AppSettings.Settings[$"Value{i}"].Value = "";
            }

            foreach (Folder folder in _folderList)
            {
                config.AppSettings.Settings[$"Number{folder.Id}"].Value = folder.Num.ToString();
                config.AppSettings.Settings[$"Value{folder.Id}"].Value = folder.Name;
            }
            config.AppSettings.Settings["Display"].Value = _folderList.Count.ToString();
            config.Save();
        }

        /// <summary>
        /// パネルを生成
        /// </summary>
        /// <param name="isInit">コンストラクタか否か</param>
        private void CreatePanel(bool isInit = false)
        {
            // コントロールを取得する
            Control.ControlCollection collection = this.folderGroup.Controls;

            int y = collection.Count != 0 ? collection[collection.Count - 1].Location.Y + 35 : 10;
            int id = collection.Count != 0 ? collection.Count + 1 : 1;
            int num = isInit ? int.Parse(LoadSetting($"Number{id}")) : id;
            string value = isInit ? LoadSetting($"Value{id}") : "";

            Panel panel = new Panel();

            NumericUpDown directoryNumber = new NumericUpDown();
            directoryNumber.Name = $"directoryNumber{id}";
            directoryNumber.Value = num;
            directoryNumber.Size = new Size(35, 20);
            directoryNumber.Location = new Point(10, 5);
            directoryNumber.Minimum = 1;
            directoryNumber.Maximum = 99;

            TextBox directory = new TextBox();
            directory.Name = $"directory{id}";
            directory.Text = value;
            directory.Size = new Size(270, 25);
            directory.Location = new Point(50, 5);
            directory.TextChanged += CheckFileName;

            panel.Controls.Add(directoryNumber);
            panel.Controls.Add(directory);
            panel.Location = new Point(5, y);
            panel.Size = new Size(380, 30);

            this.folderGroup.Controls.Add(panel);
        }

        /// <summary>
        /// パネルを削除
        /// </summary>
        private void RemovePanel()
        {
            this.folderGroup.Controls[this.folderGroup.Controls.Count - 1].Dispose();
        }

        /// <summary>
        /// フォルダ名に使用できない文字が含まれているか確認。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckFileName(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string name = textbox.Text;

            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;

            char[] invalidChars = Path.GetInvalidFileNameChars();
            if( name.IndexOfAny(invalidChars) > -1
            || Regex.IsMatch(name, @"(^|\\|/)(CON|PRN|AUX|NUL|CLOCK\$|COM[0-9]|LPT[0-9])(\.|\\|/|$)", RegexOptions.IgnoreCase))
            {
                textbox.BackColor = Color.PaleVioletRed;
                toolTip.SetToolTip(textbox, "使用出来ない文字が含まれています。");
                this.createButton.Enabled = false;
                return;
            }

            textbox.BackColor = Color.White;
            toolTip.SetToolTip(textbox, null);
            this.createButton.Enabled = true;
            return;
        }
    }
}
