using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
#region Deamon
//the app's classes of wemove project
#endregion

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiyControl.UiCore.Controls
{
    public class StretchIconButton : Button
    {
        public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register(nameof(IconData), typeof(Geometry), typeof(StretchIconButton));

        public StretchIconButton()
        {
            DefaultStyleKey = typeof(StretchIconButton);
        }
        public Geometry IconData
        {
            get { return (Geometry)GetValue(IconDataProperty); }
            set { SetValue(IconDataProperty, value); }
        }
    }
}
