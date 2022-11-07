namespace TreeViewDesignWithMVVM
{
    /// <summary>
    /// 有关盘符、文件或者文件夹的相关信息
    /// </summary>
    public class DirectoryItem
    {
        //本项类型
        public DirectoryItemType Type { get; set; }
        //本项的路径
        public string FullPath { get; set; }
        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Dirve ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
    }
}
