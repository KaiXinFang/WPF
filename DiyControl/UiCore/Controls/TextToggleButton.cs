using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DiyControl.UiCore.Controls
{
    public class TextToggleButton : ToggleButton
    {

        /// <summary>
        /// 双边文本的tooglebutton
        /// </summary>
        public string UncheckedContent
        {
            get { return (string)GetValue(UncheckedContentProperty); }
            set { SetValue(UncheckedContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UncheckedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UncheckedContentProperty =
            DependencyProperty.Register("UncheckedContent", typeof(string), typeof(TextToggleButton), new PropertyMetadata(default(string)));


    }
}
