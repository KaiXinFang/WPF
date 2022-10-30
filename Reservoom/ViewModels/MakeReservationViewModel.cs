using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Services;

namespace Reservoom.ViewModels
{
    /*
     * 这个类文件是为MakeReservationView界面
     * 上所需要的数据提供服务的
     */

    public class MakeReservationViewModel : ViewModelBase
    {
        //为MakeReservationView.xaml视图中的元素内容提供可绑定属性
        private string _username;//字段
        public string Username//对应字段的属性
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private int _floorNumber;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private DateTime _startDate = new DateTime(2021,1,1);
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = new DateTime(2021,1,8);
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        //定义按钮响应命令属性
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        //构造函数
        public MakeReservationViewModel(Hotel hotel,NavigationService reservationViewNavigationService)
        {
            //下面的this是指MakeReservationViewModel
            SubmitCommand = new SubmitMakeReservationCommand(this, hotel,reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}
