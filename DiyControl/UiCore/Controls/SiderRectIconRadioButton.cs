using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiyControl.UiCore.Controls
{
    public class SiderRectIconRadioButton : RadioButton
    {

        /// <summary>
        /// 图标
        /// </summary>
        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(SiderRectIconRadioButton), new PropertyMetadata(default(Geometry)));


    }
}
