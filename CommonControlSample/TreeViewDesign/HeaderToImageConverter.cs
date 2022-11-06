using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeViewDesign
{
    /// <summary>
    /// 转换器:将针对盘符，文件夹，文件的目录路径转换为对应的图片
    ///     界面文件传输过来是一个目录路径
    ///     要针对不同的路径，返回一个图标资源，才能赋值给Image类的Source属性
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //获取路径(value是界面文件传输过来的path值)
            var path = (string)value;
            //如果路径为空则忽略
            if (path == null)
            {
                return null;
            }
            //获取文件或者文件夹的名字
            var name = MainWindow.GetFileFolderName(path);
            
            //默认图标为文件图标
            var imagePath = "Images/file.png";
            //如果name为空，则默认为磁盘图标
            if (string.IsNullOrEmpty(name))
            {
                imagePath = "Images/driver.png";
            }
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                imagePath = "Images/file-close.png";
            }
            //否则返回一个图片
            return new BitmapImage(new Uri($"pack://application:,,,/{imagePath}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
