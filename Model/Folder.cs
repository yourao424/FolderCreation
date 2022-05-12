using System.IO;

namespace FolderCreation.Model
{
    public class Folder
    {
        public Folder(int id, int num, string name)
        {
            this.Id = id;
            this.Num = num;
            this.Name = name;
        }
        public int Id { get; set; }
        public int Num { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// フォルダ名を返す
        /// </summary>
        /// <returns></returns>
        public string GetFolderName()
        {
            return $"{this.Num.ToString("00")}_{this.Name}";
        }

        /// <summary>
        /// ディレクトリを作成
        /// </summary>
        /// <param name="baseDirectory"></param>
        public void Create(string baseDirectory)
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return;
            }
            string path = Path.Combine(baseDirectory, this.GetFolderName());
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

        }
    }
}
