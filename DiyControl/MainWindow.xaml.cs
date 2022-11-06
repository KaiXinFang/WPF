﻿using DiyControl.Base;
using DiyControl.UiCore.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiyControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //第二种：使用DataContext进行绑定
            //DataContext = new WindowsSettingsHomeButtonModel()
            //{
            //    Content = "设备",
            //    WindowTextData = "蓝牙、打印机、鼠标",
            //    WindowIconData = "M800 736H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64zM800 480H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64zM800 224H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64z M304 736h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64zM304 480h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64zM304 224h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64z\r\n                                M864 96H160a96 96 0 0 0-96 96v640a96 96 0 0 0 96 96h704a96 96 0 0 0 96-96V192a96 96 0 0 0-96-96z m32 736a32 32 0 0 1-32 32H160a32 32 0 0 1-32-32v-160h672a32 32 0 0 0 0-64H128v-192h672a32 32 0 0 0 0-64H128V192a32 32 0 0 1 32-32h704a32 32 0 0 1 32 32v640z"
            //};
        }
    }

    //数据集合绑定（写法二）
    public class MainWindowModel : NotifyPropertyChanged
    {
        //定义字段
        private ObservableCollection<WindowsSettingsHomeButtonModel> _homeButtonModels;
        //将字段封装成属性
        public ObservableCollection<WindowsSettingsHomeButtonModel> HomeButtonModels
        {
            get { return _homeButtonModels; }
            set
            {
                _homeButtonModels = value;
                RaisePropertyChanged(nameof(HomeButtonModels));
            }
        }

        private WindowsSettingsHomeButtonModel _buttonModel;

        public WindowsSettingsHomeButtonModel ButtonModel
        {
            get { return _buttonModel; }
            set
            {
                _buttonModel = value;
                RaisePropertyChanged(nameof(ButtonModel));
            }
        }

        //构造函数
        public MainWindowModel()
        {
            HomeButtonModels = new ObservableCollection<WindowsSettingsHomeButtonModel>();
            for (int i = 0; i < 4; i++)
            {
                HomeButtonModels.Add(new WindowsSettingsHomeButtonModel()
                {
                    WindowTextData = "显示、声音、通知、电源",
                    Content = "系统",
                    WindowIconData = "M896 256v469.333333H170.666667V256h725.333333zM213.333333 298.666667v384h640V298.666667H213.333333z m725.333334 469.333333v42.666667H128v - 42.666667h810.666667z"

                });
            }
            ButtonModel = HomeButtonModels.FirstOrDefault();
        }
    }

    /// <summary>
    /// 可通知的数据集合
    /// </summary>
    //第四种：数据集合绑定(写法一)
    public class WindowsSettingsHomeButtonModels : ObservableCollection<WindowsSettingsHomeButtonModel>
    {
        public WindowsSettingsHomeButtonModels()
        {
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "显示、声音、通知、电源",
                Content = "系统",
                WindowIconData = "M896 256v469.333333H170.666667V256h725.333333zM213.333333 298.666667v384h640V298.666667H213.333333z m725.333334 469.333333v42.666667H128v - 42.666667h810.666667z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "蓝牙、打印机、鼠标",
                Content = "设备",
                WindowIconData = "M800 736H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0 - 64zM800 480H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0 - 64zM800 224H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0 - 64zM304 736h - 64a32 32 0 0 0 0 64h64a32 32 0 0 0 0 - 64zM304 480h - 64a32 32 0 0 0 0 64h64a32 32 0 0 0 0 - 64zM304 224h - 64a32 32 0 0 0 0 64h64a32 32 0 0 0 0 - 64z M864 96H160a96 96 0 0 0 - 96 96v640a96 96 0 0 0 96 96h704a96 96 0 0 0 96 - 96V192a96 96 0 0 0 - 96 - 96z m32 736a32 32 0 0 1 - 32 32H160a32 32 0 0 1 - 32 - 32v - 160h672a32 32 0 0 0 0 - 64H128v - 192h672a32 32 0 0 0 0 - 64H128V192a32 32 0 0 1 32 - 32h704a32 32 0 0 1 32 32v640z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "连接Android设备和iPhone",
                Content = "手机",
                WindowIconData = "M682.667 47.652H341.984c-42.635 0-77.44 34.884-77.44 77.437v774.513c0 42.594 34.805 77.44 77.44 77.44h340.683c42.597 0 77.441-34.846 77.441-77.44V125.088c0-42.552-34.844-77.436-77.441-77.436z m-216.813 61.932H558.8c8.556 0 15.545 6.947 15.545 15.505 0 8.602-6.988 15.504-15.545 15.504h-92.945c-8.52 0-15.422-6.902-15.422-15.504 0-8.558 6.902-15.505 15.422-15.505z m46.432 836.45c-25.638 0-46.47-20.754-46.47-46.433s20.832-46.512 46.47-46.512c25.757 0 46.512 20.834 46.512 46.512s-20.754 46.434-46.512 46.434zM729.22 822.163H295.552V202.53H729.22v619.633z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "WLAN、飞行模式、VPN",
                Content = "网络和Internet",
                WindowIconData = "M512 96c229.76 0 416 186.24 416 416S741.76 928 512 928 96 741.76 96 512 282.24 96 512 96z m - 32 448l - 127.317333 0.021333c0.896 20.48 2.624 40.405333 5.12 59.669334l1.984 14.293333 2.474666 15.253333c19.754667 112.896 65.728 197.738667 117.76 222.997334L480 544z m191.317333 0.021333L544 544v312.234667c50.858667 - 24.725333 95.936 - 106.368 116.373333 - 215.509334l1.365334 - 7.488 2.474666 - 15.232a701.013333 701.013333 0 0 0 7.104 - 73.984z m - 382.698666 0H161.429333c11.648 129.066667 92.992 238.08 206.101334 289.066667 - 22.122667 - 34.282667 - 40.362667 - 76.416 - 53.76 - 124.032l - 3.029334 - 11.093333 - 3.52 - 14.165334 - 3.242666 - 14.464a744.490667 744.490667 0 0 1 - 15.36 - 125.312z m573.952 0H735.36a752.661333 752.661333 0 0 1 - 12.672 112.128l - 2.688 13.184 - 3.242667 14.464 - 3.52 14.186667c - 13.653333 52.138667 - 32.96 98.197333 - 56.789333 135.104 113.109333 - 50.986667 194.453333 - 160 206.08 - 289.066667zM367.530667 190.890667l - 2.858667 1.301333C253.013333 243.733333 172.970667 352 161.429333 480h127.189334c1.536 - 39.04 5.866667 - 76.693333 12.672 - 112.149333l2.688 - 13.184 3.242666 - 14.464 3.52 - 14.186667c13.653333 - 52.138667 32.96 - 98.197333 56.789334 - 135.104zM480 167.765333c - 50.709333 24.618667 - 95.68 105.898667 - 116.202667 214.592l - 1.536 8.405334 - 2.474666 15.232a701.034667 701.034667 0 0 0 - 7.104 74.005333H480V167.765333z m176.469333 23.146667l2.56 4.053333c20.906667 33.429333 38.229333 73.984 51.093334 119.552l3.136 11.52 3.52 14.165334 3.242666 14.464c8.362667 39.253333 13.632 81.408 15.36 125.333333h127.189334c - 11.626667 - 129.088 - 92.970667 - 238.101333 - 206.101334 - 289.066667zM544 167.765333L544 480h127.317333a707.136 707.136 0 0 0 - 5.333333 - 61.376l - 1.770667 - 12.629333 - 2.474666 - 15.232c - 19.754667 - 112.874667 - 65.706667 - 197.717333 - 117.717334 - 222.997334z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "背景、锁屏、颜色",
                Content = "个性化",
                WindowIconData = " M399.12 231.19c0 - 92.42 - 75.16 - 167.57 - 167.53 - 167.57 - 92.42 0 - 167.57 75.16 - 167.57 167.57 0 76.46 51.78 140.4 121.91 160.43l1.7 568.99h89.7V391.6c70.06 - 20.06 121.79 - 83.98 121.79 - 160.41zM231.59 327c - 52.82 0 - 95.83 - 42.99 - 95.83 - 95.81 0 - 52.84 43.01 - 95.83 95.83 - 95.83s95.79 42.99 95.79 95.83c0 52.83 - 42.97 95.81 - 95.79 95.81zM838.31 632.61l - 1.7 - 568.99h - 89.7v569.02c - 70.06 20.05 - 121.79 83.97 - 121.79 160.4 0 92.42 75.16 167.57 167.53 167.57 92.42 0 167.57 - 75.16 167.57 - 167.57 0 - 76.46 - 51.78 - 140.4 - 121.91 - 160.43z m - 45.66 256.26c - 52.82 0 - 95.79 - 42.99 - 95.79 - 95.83 0 - 52.82 42.97 - 95.81 95.79 - 95.81s95.83 42.99 95.83 95.81c0 52.85 - 43.01 95.83 - 95.83 95.83z M637.61 621.82c3.48 - 3.94 6.91 - 7.88 10.01 - 12.13 2.47 - 3.41 4.68 - 6.94 6.89 - 10.54 3.27 - 5.27 6.21 - 10.7 8.87 - 16.33 1.56 - 3.32 3.1 - 6.6 4.44 - 10.03 2.66 - 6.74 4.72 - 13.73 6.49 - 20.87 0.69 - 2.81 1.6 - 5.5 2.15 - 8.36 1.95 - 10.14 3.19 - 20.53 3.19 - 31.26 0 - 0.06 - 0.02 - 0.11 - 0.02 - 0.18s0.02 - 0.11 0.02 - 0.17c0 - 10.73 - 1.25 - 21.12 - 3.19 - 31.26 - 0.55 - 2.87 - 1.46 - 5.56 - 2.16 - 8.38 - 1.77 - 7.14 - 3.83 - 14.11 - 6.48 - 20.85 - 1.35 - 3.45 - 2.9 - 6.75 - 4.47 - 10.09a164 164 0 0 0 - 8.83 - 16.24c - 2.23 - 3.63 - 4.46 - 7.19 - 6.94 - 10.62 - 3.07 - 4.21 - 6.47 - 8.12 - 9.91 - 12.02 - 3.29 - 3.76 - 6.42 - 7.59 - 10.03 - 11.03 - 1.92 - 1.82 - 4.1 - 3.32 - 6.1 - 5.04 - 10.9 - 9.49 - 22.9 - 17.57 - 35.99 - 24.02 - 0.96 - 0.47 - 1.83 - 1.06 - 2.79 - 1.52 - 6.43 - 3.01 - 13.16 - 5.31 - 20 - 7.5 - 1.71 - 0.54 - 3.27 - 1.38 - 5 - 1.87l - 1.7 - 287.89h - 89.7v287.92c - 1.78 0.51 - 3.4 1.37 - 5.16 1.94 - 6.73 2.17 - 13.35 4.42 - 19.68 7.39 - 1.26 0.59 - 2.4 1.36 - 3.65 1.98 - 12.65 6.32 - 24.28 14.14 - 34.86 23.31 - 2.12 1.82 - 4.44 3.41 - 6.47 5.34 - 3.57 3.41 - 6.66 7.21 - 9.92 10.92 - 3.48 3.94 - 6.91 7.88 - 10.01 12.13 - 2.47 3.41 - 4.68 6.94 - 6.89 10.54a163.92 163.92 0 0 0 - 8.88 16.34c - 1.56 3.31 - 3.09 6.58 - 4.43 10.01 - 2.66 6.75 - 4.73 13.74 - 6.5 20.89 - 0.69 2.81 - 1.6 5.5 - 2.15 8.36 - 1.95 10.14 - 3.19 20.53 - 3.19 31.26 0 0.06 0.02 0.11 0.02 0.17s - 0.02 0.11 - 0.02 0.18c0 10.73 1.25 21.12 3.19 31.26 0.55 2.87 1.46 5.56 2.16 8.37 1.77 7.14 3.83 14.11 6.48 20.85 1.35 3.45 2.89 6.74 4.46 10.07 2.66 5.61 5.58 11.01 8.83 16.25 2.23 3.63 4.46 7.19 6.95 10.63 3.07 4.2 6.45 8.1 9.9 11.99 3.29 3.76 6.43 7.6 10.05 11.05 1.92 1.82 4.1 3.32 6.1 5.04 10.88 9.47 22.86 17.54 35.92 23.98 0.99 0.48 1.88 1.1 2.88 1.56 6.42 3.01 13.13 5.29 19.96 7.48 1.71 0.55 3.29 1.39 5.02 1.88l1.7 287.89h89.7V672.7c1.79 - 0.51 3.41 - 1.37 5.18 - 1.94 6.72 - 2.16 13.33 - 4.42 19.66 - 7.38 1.28 - 0.59 2.43 - 1.38 3.68 - 2 12.64 - 6.32 24.25 - 14.13 34.83 - 23.3 2.12 - 1.82 4.44 - 3.41 6.47 - 5.34 3.57 - 3.42 6.67 - 7.21 9.92 - 10.92zM512.1 607.78c - 52.76 0 - 95.67 - 42.9 - 95.77 - 95.66 0.1 - 52.76 43.05 - 95.66 95.82 - 95.66 52.76 0 95.67 42.9 95.77 95.66 - 0.11 52.76 - 43.06 95.66 - 95.82 95.66z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "卸载、默认应用、可选功能",
                Content = "应用",
                WindowIconData = "M371.732817 94.172314q25.773475 0 44.112294 17.843175t18.338819 43.616651l0 247.821878q0 25.773475 - 18.338819 44.112294t - 44.112294 18.338819l - 247.821878 0q - 25.773475 0 - 43.616651 - 18.338819t - 17.843175 - 44.112294l0 - 247.821878q0 - 25.773475 17.843175 - 43.616651t43.616651 - 17.843175l247.821878 0zM371.732817 589.81607q25.773475 0 44.112294 17.843175t18.338819 43.616651l0 248.813166q0 25.773475 - 18.338819 43.616651t - 44.112294 17.843175l - 247.821878 0q - 25.773475 0 - 43.616651 - 17.843175t - 17.843175 - 43.616651l0 - 248.813166q0 - 25.773475 17.843175 - 43.616651t43.616651 - 17.843175l247.821878 0zM868.367861 589.81607q25.773475 0 43.616651 17.843175t17.843175 43.616651l0 248.813166q0 25.773475 - 17.843175 43.616651t - 43.616651 17.843175l - 247.821878 0q - 25.773475 0 - 44.112294 - 17.843175t - 18.338819 - 43.616651l0 - 248.813166q0 - 25.773475 18.338819 - 43.616651t44.112294 - 17.843175l247.821878 0zM1006.156825 203.21394q19.82575 19.82575 19.82575 46.590513t - 19.82575 45.599226l - 184.379477 184.379477q - 19.82575 19.82575 - 46.094869 19.82575t - 46.094869 - 19.82575l - 184.379477 - 184.379477q - 18.834463 - 18.834463 - 18.834463 - 45.599226t18.834463 - 46.590513l184.379477 - 184.379477q19.82575 - 18.834463 46.094869 - 18.834463t46.094869 18.834463z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "你的账户、电子邮件、同步设置、工作、其他人员",
                Content = "账户",
                WindowIconData = "M672 320a160 160 0 1 0 - 160 160 160 160 0 0 0 160 - 160z m64 0A224 224 0 1 1 512 96a224 224 0 0 1 224 224z M224 832a32 32 0 0 1 - 64 0 352 352 0 0 1 704 0 32 32 0 0 1 - 64 0 288 288 0 0 0 - 576 0z"

            });

            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "语音、区域、日期",
                Content = "时间和语言",
                WindowIconData = "M151.041 305.246c39.883 - 59.212 94.273 - 108.096 157.291 - 141.37 23.579 - 12.449 32.6 - 41.658 20.151 - 65.239 - 12.449 - 23.578 - 41.663 - 32.602 - 65.239 - 20.15 - 77.048 40.682 - 143.541 100.44 - 192.291 172.813 - 14.895 22.117 - 9.045 52.122 13.072 67.019 8.275 5.572 17.65 8.241 26.928 8.241 15.523 - 0.001 30.765 - 7.472 40.088 - 21.314z m359.305 - 160.674c - 222.208 0 - 402.342 180.135 - 402.342 402.342 0 98.949 35.741 189.537 94.99 259.611l - 75.667 75.669c - 12.571 12.569 - 12.571 32.95 0 45.519 6.285 6.285 14.524 9.428 22.761 9.428 8.239 0 16.475 - 3.143 22.761 - 9.428l75.48 - 75.482c70.398 60.469 161.933 97.026 262.016 97.026 98.951 0 189.539 - 35.743 259.613 - 94.992l73.447 73.449c6.287 6.287 14.522 9.428 22.761 9.428 8.238 0 16.475 - 3.143 22.762 - 9.428 12.571 - 12.571 12.571 - 32.952 0 - 45.519l - 73.26 - 73.264c60.465 - 70.398 97.02 - 161.935 97.02 - 262.016 0 - 222.21 - 180.135 - 402.343 - 402.342 - 402.343z m238.979 641.319c - 63.832 63.834 - 148.706 98.988 - 238.979 98.988s - 175.147 - 35.156 - 238.979 - 98.99c - 63.832 - 63.832 - 98.988 - 148.701 - 98.988 - 238.975 0 - 90.276 35.156 - 175.146 98.988 - 238.981 63.833 - 63.833 148.706 - 98.986 238.979 - 98.986s175.147 35.154 238.979 98.986c63.833 63.835 98.988 148.705 98.988 238.981 0 90.274 - 35.156 175.143 - 98.988 238.977z m200.413 - 534.592c - 48.751 - 72.371 - 115.241 - 132.13 - 192.289 - 172.813 - 23.579 - 12.449 - 52.788 - 3.43 - 65.237 20.15 - 12.451 23.579 - 3.43 52.788 20.151 65.239 63.015 33.274 117.406 82.16 157.289 141.37 9.324 13.844 24.565 21.313 40.087 21.313 9.278 0 18.657 - 2.67 26.928 - 8.241 22.117 - 14.896 27.966 - 44.901 13.071 - 67.018zM639.095 514.727h - 96.562V321.603c0 - 17.777 - 14.41 - 32.187 - 32.187 - 32.187 - 17.775 0 - 32.187 14.41 - 32.187 32.187v225.312c0 17.775 14.412 32.187 32.187 32.187h128.749c17.777 0 32.187 - 14.412 32.187 - 32.187 0.001 - 17.778 - 14.409 - 32.188 - 32.187 - 32.188z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "Xbox、Game Bar、捕获、游戏模式",
                Content = "游戏",
                WindowIconData = "M1009.2544 537.2928 1009.2544 434.8928c0 - 162.9184 - 114.176 - 198.9632 - 187.2896 - 198.9632L541.9008 235.9296c0.4096 - 1.536 0.7168 - 3.2768 0.7168 - 4.9152l0 - 65.8432c0 - 10.3424 - 8.3968 - 18.7392 - 18.7392 - 18.7392 - 10.3424 0 - 18.7392 8.3968 - 18.7392 18.7392l0 65.8432c0 1.7408 0.2048 3.3792 0.7168 4.9152l - 3.8912 0L210.2272 235.9296c - 73.1136 0 - 187.2896 36.0448 - 187.2896 198.9632l0 102.5024 0 29.9008 0 163.4304c0 59.5968 48.3328 107.9296 107.9296 107.9296 17.408 0 34.816 0 52.1216 0 0 0 58.1632 3.6864 86.016 - 27.5456 16.5888 - 18.6368 25.1904 - 31.8464 25.1904 - 31.8464 20.5824 - 27.7504 50.176 - 41.984 83.968 - 46.592 7.3728 - 1.024 14.9504 - 1.6384 22.4256 - 1.9456l76.0832 0 129.6384 0c7.4752 0.3072 40.1408 0.9216 47.616 1.9456 33.792 4.608 63.3856 18.8416 83.968 46.592 0 0 8.704 13.2096 25.1904 31.8464 27.8528 31.3344 86.016 27.5456 86.016 27.5456 17.408 0 34.816 0 52.1216 0 59.5968 0 107.9296 - 48.3328 107.9296 - 107.9296L1009.152 567.1936 1009.2544 537.2928zM401.2032 510.5664l - 114.176 0.3072L286.72 625.2544c0 10.3424 - 8.3968 18.7392 - 18.7392 18.7392l0 0c - 10.3424 0 - 18.7392 - 8.3968 - 18.7392 - 18.7392l0.2048 - 114.2784 - 114.0736 0.3072 0 0c - 10.3424 0 - 18.7392 - 8.3968 - 18.7392 - 18.7392 0 - 10.3424 8.2944 - 18.7392 18.7392 - 18.7392l114.2784 - 0.3072 0.2048 - 114.4832c0 - 10.3424 8.3968 - 18.7392 18.7392 - 18.7392l0 0c10.3424 0 18.7392 8.3968 18.7392 18.7392l - 0.2048 114.3808 114.0736 - 0.3072 0 0c10.3424 0 18.7392 8.3968 18.7392 18.7392C419.9424 502.0672 411.5456 510.464 401.2032 510.5664zM688.2304 488.1408c - 31.232 0 - 56.6272 - 25.3952 - 56.6272 - 56.6272 0 - 31.232 25.3952 - 56.5248 56.6272 - 56.5248s56.6272 25.3952 56.6272 56.5248C744.7552 462.7456 719.4624 488.1408 688.2304 488.1408zM834.56 621.2608c - 32.256 0 - 58.4704 - 26.2144 - 58.4704 - 58.368 0 - 32.256 26.2144 - 58.4704 58.4704 - 58.4704 32.256 0 58.4704 26.2144 58.4704 58.4704C893.0304 595.0464 866.816 621.2608 834.56 621.2608z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "讲述人、放大镜、高对比度",
                Content = "轻松使用",
                WindowIconData = "M879.978667 120.128 490.453333 120.128l - 232.661333 - 108.586667c - 12.8 - 5.952 - 26.304 - 9.002667 - 40.170667 - 9.002667 - 52.330667 0 - 94.954667 42.645333 - 94.954667 95.061333l0 24.256C53.376 132.245333 0 191.978667 0 264.128L0 877.44c0 79.445333 64.618667 144.021333 144.021333 144.021333L512 1021.461333l367.978667 0c79.445333 0 144.021333 - 64.576 144.021333 - 144.021333L1024 264.128C1024 184.704 959.424 120.106667 879.978667 120.128zM165.397333 97.6c0 - 32.32 27.136 - 52.330667 52.224 - 52.330667 7.573333 0 14.997333 1.685333 22.101333 4.992l250.922667 117.098667 0 774.677333L195.541333 804.352C177.237333 795.733333 165.397333 777.173333 165.397333 756.949333L165.397333 97.6zM42.730667 877.44 42.730667 264.106667c0 - 48.533333 34.325333 - 89.088 79.936 - 98.922667l0 591.786667c0 36.714667 21.482667 70.506667 54.784 86.08l290.816 135.658667L144.021333 978.709333C88.149333 978.709333 42.730667 933.269333 42.730667 877.44zM981.269333 877.44c0 55.850667 - 45.44 101.290667 - 101.290667 101.290667L532.970667 978.730667c0.149333 - 1.066667 0.405333 - 2.112 0.405333 - 3.178667L533.376 162.837333l346.602667 0c55.850667 0 101.290667 45.44 101.290667 101.290667L981.269333 877.44z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "查找我的文件、权限",
                Content = "搜索",
                WindowIconData = "M575.069091 739.141818c - 60.043636 0 - 120.32 - 16.989091 - 172.916364 - 51.898182 - 18.152727 - 12.334545 - 34.210909 - 25.367273 - 48.872727 - 40.029091 - 14.661818 - 14.661818 - 27.694545 - 30.487273 - 39.796364 - 48.64 - 82.152727 - 124.043636 - 65.396364 - 290.443636 39.796364 - 395.636363a23.179636 23.179636 0 1 1 32.814545 32.814545c - 89.6 89.6 - 104.029091 231.330909 - 33.978181 336.756364 10.472727 15.36 21.643636 29.090909 33.978181 41.658182 12.567273 12.567273 26.298182 23.738182 41.89091 34.210909 105.425455 69.818182 247.156364 55.389091 336.756363 - 34.210909 104.261818 - 104.261818 104.261818 - 274.152727 0 - 378.414546 - 64.232727 - 64.232727 - 155.694545 - 91.229091 - 244.829091 - 72.610909 - 12.8 2.56 - 24.901818 - 5.352727 - 27.694545 - 17.92 - 2.56 - 12.567273 5.352727 - 24.901818 17.92 - 27.694545 104.494545 - 22.109091 212.014545 9.774545 287.418182 85.178182 122.414545 122.414545 122.414545 321.861818 0 444.276363 - 60.509091 60.974545 - 141.265455 92.16 - 222.487273 92.16z M155.927273 928.116364c - 19.781818 0 - 39.563636 - 7.447273 - 54.458182 - 22.574546l - 6.283636 - 6.283636a77.125818 77.125818 0 0 1 0 - 108.916364l221.090909 - 221.090909c4.887273 - 4.887273 11.869091 - 7.214545 18.618181 - 6.749091 6.981818 0.698182 13.265455 4.421818 16.989091 10.24 10.472727 15.592727 21.643636 29.323636 34.210909 41.658182 12.567273 12.567273 26.298182 23.738182 41.89091 34.210909 5.818182 3.956364 9.541818 10.24 10.24 16.989091 0.698182 6.981818 - 1.861818 13.730909 - 6.749091 18.618182l - 221.090909 221.090909c - 15.127273 15.36 - 34.676364 22.807273 - 54.458182 22.807273z m174.08 - 306.734546L128 823.389091a30.487273 30.487273 0 0 0 0 43.054545l6.283636 6.283637c11.869091 11.869091 31.185455 11.869091 43.054546 0l202.007273 - 202.007273c - 9.309091 - 7.447273 - 17.92 - 15.127273 - 26.065455 - 23.272727 - 8.145455 - 8.378182 - 15.825455 - 16.989091 - 23.272727 - 26.065455z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "位置、摄像头、麦克风",
                Content = "隐私",
                WindowIconData = "M515.050667 53.333333c112.128 0 202.602667 94.08 205.632 210.496l0.085333 6.037334 - 0.021333 60.8H864v597.333333h - 704v - 597.333333h149.312l0.021333 - 60.8c0 - 119.168 91.648 - 216.533333 205.717334 - 216.533334z m284.949333 341.333334h - 576v469.333333h576v - 469.333333z m - 170.666667 106.666666v234.666667h - 234.666666v - 234.666667h234.666666z m - 64 64h - 106.666666v106.666667h106.666666v - 106.666667z m - 50.282666 - 448c - 76.202667 0 - 139.050667 65.066667 - 141.653334 147.264l - 0.064 5.269334 - 0.021333 60.8h283.434667v - 60.8c0 - 84.650667 - 63.872 - 152.533333 - 141.696 - 152.533334z"

            });
            Add(new WindowsSettingsHomeButtonModel()
            {
                WindowTextData = "Windows更新、恢复、备份",
                Content = "更新和安全",
                WindowIconData = "M896.384 494.634667A21.461333 21.461333 0 0 1 917.333333 469.333333a21.333333 21.333333 0 0 1 21.290667 22.826667A427.093333 427.093333 0 0 1 725.333333 881.493333C521.258667 999.338667 260.309333 929.408 142.506667 725.333333a434.773333 434.773333 0 0 1 - 5.674667 - 10.154666L119.466667 786.645333a19.669333 19.669333 0 0 1 - 24.917334 14.378667 22.058667 22.058667 0 0 1 - 15.061333 - 26.112l29.482667 - 121.557333a19.669333 19.669333 0 0 1 24.917333 - 14.378667l120.021333 35.242667c11.050667 3.242667 17.792 14.933333 15.061334 26.112a19.669333 19.669333 0 0 1 - 24.917334 14.378666l - 70.101333 - 20.565333 5.504 9.856A384 384 0 0 0 704 844.544a384.341333 384.341333 0 0 0 192.384 - 349.866667zM128 490.88a21.333333 21.333333 0 1 1 - 42.325333 - 4.053333C94.634667 349.312 170.368 216.576 298.666667 142.506667a425.941333 425.941333 0 0 1 373.333333 - 26.026667 424.618667 424.618667 0 0 1 196.266667 160.682667l17.493333 - 72.277334a19.669333 19.669333 0 0 1 24.96 - 14.378666c11.008 3.242667 17.792 14.933333 15.061333 26.112l - 29.482666 121.557333a19.669333 19.669333 0 0 1 - 24.917334 14.378667l - 120.021333 - 35.242667a22.058667 22.058667 0 0 1 - 15.104 - 26.112 19.669333 19.669333 0 0 1 24.917333 - 14.378667l69.077334 20.266667a381.738667 381.738667 0 0 0 - 174.208 - 141.056 383.189333 383.189333 0 0 0 - 336.042667 23.424C204.8 245.930667 136.32 367.445333 128 490.88z"

            });

        }
    }

    //继承INotifyPropertyChanged类，当属性发生变化时，使用其中的PropertyChanged事件进行通知
    //这样才能在主界面做出更改
    //第一种：使用静态资源进行绑定
    public class WindowsSettingsHomeButtonModel : NotifyPropertyChanged
    {
        public WindowsSettingsHomeButtonModel()
        {
            //Content = "系统";
            //WindowTextData = "显示、声音、通知、电源";
            //WindowIconData = "M896 256v469.333333H170.666667V256h725.333333zM213.333333 298.666667v384h640V298.666667H213.333333z m725.333334 469.333333v42.666667H128v-42.666667h810.666667z";

            //Task.Run(() =>
            //{
            //    Thread.Sleep(4000);
            //    Content = "设备";
            //    WindowTextData = "蓝牙、打印机、鼠标";
            //    WindowIconData = "M800 736H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64zM800 480H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64zM800 224H448a32 32 0 0 0 0 64h352a32 32 0 0 0 0-64z M304 736h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64zM304 480h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64zM304 224h-64a32 32 0 0 0 0 64h64a32 32 0 0 0 0-64z\r\n                                M864 96H160a96 96 0 0 0-96 96v640a96 96 0 0 0 96 96h704a96 96 0 0 0 96-96V192a96 96 0 0 0-96-96z m32 736a32 32 0 0 1-32 32H160a32 32 0 0 1-32-32v-160h672a32 32 0 0 0 0-64H128v-192h672a32 32 0 0 0 0-64H128V192a32 32 0 0 1 32-32h704a32 32 0 0 1 32 32v640z";

            //});

            //初始化命令
            ShowCommand = new RelayCommand(() =>
            {
                MessageBox.Show($"点击了一下{Content}按钮");
            });
        }

        private void ShowMessage()
        {
            throw new NotImplementedException();
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }

        private string _windowTextData;
        public string WindowTextData
        {
            get
            {
                return _windowTextData;
            }
            set
            {
                _windowTextData = value;
                RaisePropertyChanged(nameof(WindowTextData));
            }
        }

        private string _windowIconData;

        public string WindowIconData
        {
            get { return _windowIconData; }
            set
            {
                _windowIconData = value;
                RaisePropertyChanged(nameof(WindowIconData));
            }
        }

        //创建一个命令
        public RelayCommand ShowCommand { get; set; }

    }
}
