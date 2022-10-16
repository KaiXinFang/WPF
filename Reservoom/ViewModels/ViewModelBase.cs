using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Reservoom.ViewModels
{
    //继承属性更改时通知的一个类
    public class ViewModelBase : INotifyPropertyChanged
    {
        //定义属性更改处理事件
        public event PropertyChangedEventHandler PropertyChanged;
        
        //通知UI界面随着属性的变化来更改界面信息
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
