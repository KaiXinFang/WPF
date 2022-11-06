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
    public class WithDescTextIconButton : Button
    {
        //定义一个TextIconData依赖属性
        public static readonly DependencyProperty WithDescIconDataProperty = DependencyProperty.Register(nameof(WithDescIconData),
            typeof(Geometry), typeof(WithDescTextIconButton), new PropertyMetadata(default(Geometry)));
        //对TextIconData属性进行封装，方便获取和修改
        public Geometry WithDescIconData
        {
            get { return (Geometry)GetValue(WithDescIconDataProperty); }
            set { SetValue(WithDescIconDataProperty, value); }
        }

        public static readonly DependencyProperty WithDescTextDataProperty = DependencyProperty.Register(nameof(WithDescTextData),
            typeof(string), typeof(WithDescTextIconButton), new PropertyMetadata(default(string)));
        public string WithDescTextData
        {
            set { SetValue(WithDescTextDataProperty, value); }
            get { return (string)GetValue(WithDescTextDataProperty); }
        }
    }
}
