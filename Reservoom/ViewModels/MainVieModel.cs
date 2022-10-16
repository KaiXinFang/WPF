using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class MainVieModel:ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainVieModel(Hotel hotel)
        {
            CurrentViewModel = new MakeReservationViewModel(hotel);
        }
    }
}
