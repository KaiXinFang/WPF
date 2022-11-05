using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStyleDesign.TestData
{
    public class Data
    {
        public Data()
        {
            listData = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                listData.Add(new { Name = "老王" + i, Age = 12, Sex = "男", Time = DateTime.Now });
            }
        }
        public List<object> listData { get; set; }

    }
}
