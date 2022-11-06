using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TreeViewDesign
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region on Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //GetLogicalDrives检查电脑逻辑驱动器(内存盘)的名称
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //创建新的item
                var item = new TreeViewItem()
                {
                    //设置头节点名称和路径
                    Header = drive,
                    Tag = drive//相当于为当前节点设置标签名称并指定跳转路径
                };

                //可理解成添加子节点
                item.Items.Add(null);

                //监听树节点扩展(当 IsExpanded 属性从 false 更改为 true 时发生)
                item.Expanded += Folder_Expand;
                //添加到树结构中
                FolderView.Items.Add(item);
            }
        }
        #endregion

        //点击节点进行展开时，响应展开事件
        #region Folder_Expand
        private void Folder_Expand(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            //如果当前节点有子节点，说明之前打开过这个节点，则不再进行遍历查找的操作
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }
            //清空当前节点
            item.Items.Clear();
            //获取整体路径
            var fullPath = (string)item.Tag;
            #region get Folders
            //创建一个存放目录的空列表
            var directories = new List<string>();
            //尝试从改路径中获取文件夹
            try
            {
                //从当前路径获取文件夹
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {

            }
            //遍历每一个文件夹路径
            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath//把文件夹路径赋值给Tag属性
                };
                //添加子项以触发扩展事件（文件夹有子项可以Expand,但是文件本身就不能在Expand了）
                subItem.Items.Add(null);
                subItem.Expanded += Folder_Expand;//相当于递归
                //将子项加入父级item(就是事件触发者)
                item.Items.Add(subItem);
            });
            #endregion

            #region get Files
            //创建一个存放目录的空列表
            var files = new List<string>();
            //尝试从该路径中获取文件
            try
            {
                //从当前路径获取文件
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch
            {

            }
            //遍历每一个文件
            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath//把文件路径赋值给Tag属性
                };
                //文件本身就不能在Expand,所以不再挂接Expanded事件(这是和遍历文件夹的唯一区别)
                //将子项加入父级item(就是事件触发者)
                item.Items.Add(subItem);
            });
            #endregion
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
    }
    #endregion 

}
