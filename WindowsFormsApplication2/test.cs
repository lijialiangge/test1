using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class test
    {
        [ExcelColumn("设备ID")]
        public string devcieid { get; set; }
        [ExcelColumn("报警名称")]
        public string AlarmName { get; set; }
        [ExcelColumn("时间")]
        public DateTime starttime { get; set; }
    }
}
