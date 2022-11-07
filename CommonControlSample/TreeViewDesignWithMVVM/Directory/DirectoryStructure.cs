using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeViewDesignWithMVVM
{
    /// <summary>
    /// 查询文件夹信息
    /// </summary>
    public static class DirectoryStructure
    {
        //获取电脑上所有的盘符,返回值是一个列表
        #region GetLogicalDrivers
        public static List<DirectoryItem> GetLogicalDrivers()
        {
            //集合里面保存到都是路径
            //Select()函数将集合按照条件投影成新格式的集合
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Dirve }).ToList();
        }
        #endregion 

        #region GetDirectoryContents
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region get Folders

            //尝试从改路径中获取文件夹
            try
            {
                //从当前路径获取文件夹
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch
            {

            }
            #endregion

            #region get Files
            //尝试从该路径中获取文件
            try
            {
                //从当前路径获取文件
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch
            {

            }
            #endregion
            return items;
        }
        #endregion

        #region GetFileFolderName
        public static string GetFileFolderName(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return string.Empty;
            }
            //统一路径中的 / 号，便于查找
            var normallizedPath = directoryPath.Replace('/', '\\');
            //寻找最后一个 \ 出现的索引
            var lastIndex = normallizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
            {
                return directoryPath;
            }
            //返回文件名或者文件夹名
            return directoryPath.Substring(lastIndex + 1);
        }
        #endregion 
    }
}
