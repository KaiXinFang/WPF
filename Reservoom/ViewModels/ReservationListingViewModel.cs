using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Services;

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
        private readonly ObservableCollection<ReservationViewModel> _reservationViewModels;

        //提供外部可访问的属性Reservations(可以用来视图数据的绑定)，间接访问只读属性_reservations
        public IEnumerable<ReservationViewModel> ReservationViewModels => _reservationViewModels;
        //定义按钮命令属性
        public ICommand MakeReservationCommand { get; }

        public readonly Hotel _hotel;

        //构造函数
        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            _hotel = hotel;
            _reservationViewModels = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

            UpdateReservations();
        }

        private void UpdateReservations()
        {
            _reservationViewModels.Clear();
            //浏览酒店的ReservationBook信息，并显示到界面上
            foreach(Reservation reservation in _hotel.GetAllReservations())
            {
                //将浏览到的每一条reservation给ReservationViewModel这个类，因为这个类中的属性是和
                //显示界面绑定的
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);

                _reservationViewModels.Add(reservationViewModel);
            }
        }
    }
}
