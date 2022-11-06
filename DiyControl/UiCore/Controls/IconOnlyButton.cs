using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiyControl.UiCore.Controls
{

    public class IconOnlyButton : Button
    {
        public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register(nameof(IconData), typeof(Geometry),
            typeof(IconOnlyButton), new PropertyMetadata(default(Geometry)));
        public Geometry IconData
        {
            get => (Geometry)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }
    }
}
