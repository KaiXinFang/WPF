using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DynamicCreateDataGridData
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DataGrid _dataGrid;
        public MainWindowViewModel(DataGrid dataGrid)
        {
            _dataGrid = dataGrid;
            DynamicCreateColumn();
            InitData();
        }

        private void InitData()
        {
            /*ExpandoObject:表示一个对象，该对象包含可在运行时动态添加和移除的成员*/
            List<ExpandoObject> students = new List<ExpandoObject>();
            for (int i = 0; i < 10; i++)
            {
                dynamic obj = new ExpandoObject();
                /*下面的属性要和DataGrid中的属性一致*/
                obj.Name = "张" + i.ToString();
                obj.Grade = (i + 1).ToString();
                obj.Major = "专业" + i.ToString();
                obj.Age = (i + 10).ToString();
                obj.City = "上海";
                obj.Address = "张江金科路" + i + "号";
                obj.Phone = "123456789" + i.ToString();
                students.Add(obj);//加入列表中
            }
            _dataGrid.ItemsSource = students;//指定DataGrid的数据源
        }

        private void DynamicCreateColumn()
        {
            DataGridTextColumn cityColumn = new DataGridTextColumn();
            cityColumn.Header = "城市";
            cityColumn.Binding = new Binding("City");//将列与数据源中的属性进行绑定
            _dataGrid.Columns.Add(cityColumn);//添加新列到DataGrid表格中

            DataGridTextColumn addressColumn = new DataGridTextColumn();
            addressColumn.Header = "详细地址";
            addressColumn.Binding = new Binding("Address");//将列与数据源中的属性进行绑定
            _dataGrid.Columns.Add(addressColumn);//添加新列到DataGrid表格中

            DataGridTextColumn phoneColumn = new DataGridTextColumn();
            phoneColumn.Header = "电话号码";
            phoneColumn.Binding = new Binding("Phone");//将列与数据源中的属性进行绑定
            _dataGrid.Columns.Add(phoneColumn);//添加新列到DataGrid表格中
        }
    }

}
