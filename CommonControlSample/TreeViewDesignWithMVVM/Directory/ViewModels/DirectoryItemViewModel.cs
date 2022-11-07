using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TreeViewDesignWithMVVM
{
    public class DirectoryItemViewModel : ViewModelBase
    {
        #region 属性
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

        //子节点收集器
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        //判断节点是否能够展开
        public bool CanExpand
        {
            get
            {
                return this.Type != DirectoryItemType.File;
            }
        }

        //判断节点是否曾展开过
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //如果界面通知节点展开
                if (value == true)
                {
                    //查找所有子节点并展开
                    Expand();
                }
                else
                {
                    this.ClearChildren();
                }
            }
        }
        #endregion

        #region 命令
        //通知展开节点
        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }
        #endregion

        #region 帮助函数
        //清除节点子项并重新创建子节点收集器
        private void ClearChildren()
        {
            //清除并重新赋值
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            //如果不是文件，应该添加子项
            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }
        }

        //展开节点
        private void Expand()
        {
            //文件是不能打开的
            if (this.Type == DirectoryItemType.File)
                return;
            //查询所有子节点
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));//循环调用，类似递归，查找所有子节点

        }
        #endregion
    }
}
