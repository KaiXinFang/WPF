using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeViewDesignWithMVVM
{
    /// <summary>
    /// 转换器:将针对盘符，文件夹，文件的目录路径转换为对应的图片
    ///     界面文件传输过来是一个目录路径
    ///     要针对不同的路径，返回一个图标资源，才能赋值给Image类的Source属性
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //默认图标为文件图标
            var imagePath = "Images/file.png";
            //如果name为空，则默认为磁盘图标
            switch((DirectoryItemType)value)
            {
                case DirectoryItemType.Dirve:
                    imagePath = "Images/driver.png";
                    break;
                case DirectoryItemType.Folder:
                    imagePath = "Images/file-close.png";
                    break;
            }
            //返回一个图片
            return new BitmapImage(new Uri($"pack://application:,,,/{imagePath}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
