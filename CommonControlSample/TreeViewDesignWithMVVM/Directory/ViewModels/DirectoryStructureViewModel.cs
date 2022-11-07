using System.Collections.ObjectModel;
using System.Linq;

namespace TreeViewDesignWithMVVM
{
    public class DirectoryStructureViewModel : ViewModelBase
    {
        //主机中所有文件夹的集合
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            //获取主机盘符
            var children = DirectoryStructure.GetLogicalDrivers();
            //使用数据创建对应视图
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath,DirectoryItemType.Dirve)));
        }
    }
}