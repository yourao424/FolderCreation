
namespace FolderCreation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseDirectory = new System.Windows.Forms.TextBox();
            this.baseDirectrySelectBtn = new System.Windows.Forms.Button();
            this.baseDirectoryLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.folderGroup = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // baseDirectory
            // 
            this.baseDirectory.Location = new System.Drawing.Point(13, 31);
            this.baseDirectory.Name = "baseDirectory";
            this.baseDirectory.Size = new System.Drawing.Size(349, 23);
            this.baseDirectory.TabIndex = 0;
            // 
            // baseDirectrySelectBtn
            // 
            this.baseDirectrySelectBtn.Location = new System.Drawing.Point(368, 31);
            this.baseDirectrySelectBtn.Name = "baseDirectrySelectBtn";
            this.baseDirectrySelectBtn.Size = new System.Drawing.Size(33, 23);
            this.baseDirectrySelectBtn.TabIndex = 1;
            this.baseDirectrySelectBtn.Text = "...";
            this.baseDirectrySelectBtn.UseVisualStyleBackColor = true;
            this.baseDirectrySelectBtn.Click += new System.EventHandler(this.BaseDirectrySelectBtn_Click);
            // 
            // baseDirectoryLabel
            // 
            this.baseDirectoryLabel.AutoSize = true;
            this.baseDirectoryLabel.Location = new System.Drawing.Point(13, 13);
            this.baseDirectoryLabel.Name = "baseDirectoryLabel";
            this.baseDirectoryLabel.Size = new System.Drawing.Size(75, 15);
            this.baseDirectoryLabel.TabIndex = 2;
            this.baseDirectoryLabel.Text = "フォルダを選択";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 61);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(57, 23);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // folderGroup
            // 
            this.folderGroup.Location = new System.Drawing.Point(13, 90);
            this.folderGroup.Name = "folderGroup";
            this.folderGroup.Size = new System.Drawing.Size(388, 365);
            this.folderGroup.TabIndex = 14;
            this.folderGroup.TabStop = false;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(76, 61);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(57, 23);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(326, 461);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 15;
            this.createButton.Text = "作成";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 488);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.folderGroup);
            this.Controls.Add(this.baseDirectoryLabel);
            this.Controls.Add(this.baseDirectrySelectBtn);
            this.Controls.Add(this.baseDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "FolderCreation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseDirectory;
        private System.Windows.Forms.Button baseDirectrySelectBtn;
        private System.Windows.Forms.Label baseDirectoryLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox folderGroup;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button removeButton;
    }
}