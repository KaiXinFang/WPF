using System;
using System.Windows.Input;

namespace DiyControl.Base
{
    //第三种：命令绑定
    public class RelayCommand : ICommand
    {
        private readonly Action mExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action executeAct)
        {
            mExecute = executeAct;
        }

        //决定是否可以执行此命令
        public bool CanExecute(object parameter)
        {
            //在这里可以进行判断，什么条件下能执行命令，什么条件下不能执行命令
            //这里是总是执行该命令
            return true;
        }

        //此命令需要执行的代码
        public void Execute(object parameter)
        {
            //如果mExecute不为null，则执行mExecute.Invoke()
            mExecute?.Invoke();
        }
    }
}
