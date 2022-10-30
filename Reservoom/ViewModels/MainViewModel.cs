using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        //用 => 直接获取值，表明是只读属性
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            //程序刚开始运行执行到此时，NavigationStore 中的CurrentViewModel已经在APP.xaml.cs代码中赋值
            //即使下面的这行代码对更新进行绑定，界面也不会进行响应，只会影响运行之后的CurrentViewModel属性更新操作
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        //通知界面有属性发生了变化，要进行界面更新
        private void OnCurrentViewModelChanged()
        {
            //调用父类 ViewModelBase 的方法
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
