using Reservoom.Commands;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    /*
     * 这个类文件是为ReservationListingView界面
     * 上所需要的数据提供服务的
     */

    public class ReservationListingViewModel : ViewModelBase
    {
        //定义可以查看收集到信息的变量，但是尽量不要直接访问Reservation类中的数据
        //所以重新定义一个ReservationViewModel做中间数据获取桥梁
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        //提供外部可访问的属性Reservations(可以用来视图数据的绑定)，间接访问只读属性_reservations
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        //定义按钮命令属性
        public ICommand MakeReservationCommand { get; }

        //构造函数
        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand();

            //添加住宿人员的信息（目前是手动添加，实际上应该从界面元素中获取，待后续...）
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "SingletonSean", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "Joe", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 4), "Mary", DateTime.Now, DateTime.Now)));
        }
    }
}
