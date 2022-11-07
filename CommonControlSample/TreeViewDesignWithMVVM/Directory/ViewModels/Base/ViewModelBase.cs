using System.ComponentModel;
using PropertyChanged;

namespace TreeViewDesignWithMVVM
{
    //使用 [AddINotifyPropertyChangedInterface](注意要引用PropertyChanged.fody包)
    //这个特性可以简化 属性变化 的通知，只需定义属性
    //当属性变化时，会自动通知界面更改信息，不再需要写响应属性变化的函数
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}