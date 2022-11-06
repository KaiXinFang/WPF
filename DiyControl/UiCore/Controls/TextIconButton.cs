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
    public class TextIconButton : Button
    {
        //定义一个TextIconData依赖属性
        public static readonly DependencyProperty TextIconDataProperty = DependencyProperty.Register(nameof(TextIconData),
            typeof(Geometry), typeof(TextIconButton), new PropertyMetadata(default(Geometry)));
        //对TextIconData属性进行封装，方便获取和修改
        public Geometry TextIconData
        {
            get { return (Geometry)GetValue(TextIconDataProperty); }
            set { SetValue(TextIconDataProperty, value); }
        }
    }
}
