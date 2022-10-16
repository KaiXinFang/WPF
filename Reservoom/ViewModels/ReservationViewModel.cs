using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    /*
     * 这个类也是一个数据获取桥梁
     *      用来获取Reservation类中的各种属性参数，提供
     *      给ReservationListingViewModel类进行使用
     */
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        //使用Lambda表达式定义只读属性，省略了get关键字
        //在变量后面加 ？
        //      表示：如果_reservation.RoomID不为null,
        //              则执行_reservation.RoomID.ToString()
        public string RoomID => _reservation.RoomID?.ToString();
        public string Username => _reservation.Username;
        public string StartDate => _reservation.StartTime.ToString("d");
        public string EndDate => _reservation.EndTime.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
