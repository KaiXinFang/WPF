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

    public class WindowsSettingsHomeButton : Button
    {
        //定义一个TextIconData依赖属性
        public static readonly DependencyProperty WindowIconDataProperty = DependencyProperty.Register(nameof(WindowIconData),
            typeof(Geometry), typeof(WindowsSettingsHomeButton), new PropertyMetadata(default(Geometry)));
        //对TextIconData属性进行封装，方便获取和修改
        public Geometry WindowIconData
        {
            get { return (Geometry)GetValue(WindowIconDataProperty); }
            set { SetValue(WindowIconDataProperty, value); }
        }

        public static readonly DependencyProperty WindowTextDataProperty = DependencyProperty.Register(nameof(WindowTextData),
            typeof(string), typeof(WindowsSettingsHomeButton), new PropertyMetadata(default(string)));
        public string WindowTextData
        {
            set { SetValue(WindowTextDataProperty, value); }
            get { return (string)GetValue(WindowTextDataProperty); }
        }
    }
}
