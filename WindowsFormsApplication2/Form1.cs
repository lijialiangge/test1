using LinqToExcel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        DataTable dt, dt1;
        string UpdateNetworkStatus;
        IList<NetworkStatus> networkstatus_old = new List<NetworkStatus>();
        IList<NetworkStatus> networkstatus_new = new List<NetworkStatus>();

        private ScanerHook listener = new ScanerHook();
        Alarm_real_time alarm_real_time = new Alarm_real_time();
        List<KeyValue> list_alarm = new List<KeyValue>();
        //BardCodeHooK BarCode = new BardCodeHooK();
        string model;


        public Form1()
        {
            InitializeComponent();
           // BarCode.BarCodeEvent += new BardCodeHooK.BardCodeDeletegate(BarCode_BarCodeEvent);
            listener.ScanerEvent += Listener_ScanerEvent;
        }
        DB db = new DB();
        string[] a = { "1", "0", "3", "0", "5" };
        //private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);

        //private void ShowInfo(BardCodeHooK.BarCodes barCode)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
        //    }
        //    else
        //    {
        //        textBox1.Text = barCode.KeyName;
        //        textBox2.Text = barCode.VirtKey.ToString();
        //        textBox3.Text = barCode.ScanCode.ToString();
        //        textBox4.Text = barCode.Ascll.ToString();
        //        textBox5.Text = barCode.Chr.ToString();
        //        textBox6.Text = barCode.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入
        //        textBox7.Text += barCode.KeyName;
        //        //MessageBox.Show(barCode.IsValid.ToString());
        //    }
        //}







        //void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        //{
        //    ShowInfo(barCode);
        //}








        private void Listener_ScanerEvent(ScanerHook.ScanerCodes codes)
        {

            string KeyDownCount = codes.KeyDownCount.ToString();
            string message = codes.Event.message.ToString();
            string paramH = codes.Event.paramH.ToString();
            string paramL = codes.Event.paramL.ToString();
            string CurrentChar = codes.CurrentChar.ToString();
            string Result = codes.Result.ToString();
            string isShift = codes.isShift.ToString();
            string CurrentKey = codes.CurrentKey.ToString();
            textBox1.Text = KeyDownCount;
            textBox2.Text = message;
            textBox3.Text = paramH;
            textBox4.Text = paramL;
            textBox5.Text = CurrentChar;
            textBox6.Text = Result;
            textBox7.Text = isShift;

            textBox8.Text = CurrentKey;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //var fileName = System.IO.Path.Combine(@"D:\test\", "test.xls");
            //DateTime dt = Convert.ToDateTime("2019-8-1");
            //var excel = new ExcelQueryFactory(fileName);
            //var query = (from c in excel.Worksheet<test>()
            //             where c.starttime == dt
            //             select c);
            //List<test> ts = new List<test>();
            //foreach (var item in query)
            //{
            //    test t = new test();
            //    t.devcieid = item.devcieid;
            //    t.AlarmName = item.AlarmName;
            //    ts.Add(t);
            //    MessageBox.Show("devcieid:" + item.devcieid + "\r\n" + "AlarmName:" + item.AlarmName);
            //}


            //Dictionary<string, string> test = new Dictionary<string, string>();
            //Dictionary<string, string> test2 = new Dictionary<string, string>();
            //test.Add("a", "True");
            //test.Add("b", "false");
            //test.Add("c", "True");
            //test.Add("d", "false");
            //test.Add("e", "True");

            //foreach (var item in test)
            //{
            //    if (item.Value == "True")
            //    {
            //        test2.Add(item.Key,item.Value);
            //    }
            //}


            //foreach (var item in test2)
            //{
            //    MessageBox.Show(item.Key.ToString());
            //}
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Stop();
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            
            if (textBox6.Text.Length > 0)
            {
                //MessageBox.Show("条码长度：" + textBox6.Text.Length + "\n条码内容：" + textBox6.Text, "系统提示");
            }
        }



            //testStudents = new List<NetworkStatus>();

           
        



        /// <summary>
        /// 开始比较从数据库读取到的数据集IList和上一次读取结果保存的值是否一致，一致则改变网络状态为offline，不一致则覆盖这次读到的数据
        /// </summary>
        /// <param name="networkstatus_old"></param>
        /// <param name="networkstatus_new"></param>

        private void startCompare(IList<NetworkStatus> networkstatus_old, IList<NetworkStatus> networkstatus_new)
        {
            try
            {
                var jiaoji = networkstatus_old.Intersect(networkstatus_new, new StudentListEquality2()).ToList();//交集 
                //var ChaJi = networkstatus_new.Except(testStudents).ToList();//差集
                jiaoji.ForEach(x =>
                {
                    networkstatus_new.Clear();
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        networkstatus_new.Add(new NetworkStatus(dt1.Rows[i][0].ToString(), dt1.Rows[i][1].ToString()));
                    }
                    //如果version没变化，则改变网络状态
                    UpdateNetworkStatus = "DECLARE @flag AS int begin tran select @flag=Versions from AllStatus where DeviceId='" + x.DeviceId.ToString() + "' update AllStatus set NetworkStatus='offline'WHERE DeviceId='" + x.DeviceId.ToString() + "' and Versions=@flag  commit TRAN";
                    int ii = db.ExecuteNonQuery(UpdateNetworkStatus);
                });
                networkstatus_new.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    networkstatus_new.Add(new NetworkStatus(dt1.Rows[i][0].ToString(), dt1.Rows[i][1].ToString()));
                }
            }
            catch (Exception ex)
            {
                
            }

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            //string str = "server=10.10.100.62;User Id=root;password=123456;Database=a60test;";
            string str = "data source=10.10.100.62;database=a60test;user id=root;password=123456;";//pooling代表是否使用连接池
            MySqlConnection conn = new MySqlConnection(str);
            int year = System.DateTime.Now.Year;
            string sql = "select * from " + " cap" + year;
            //string sql = "select * from cap2020";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                MessageBox.Show("打开成功！");
                List<test2> tt2 = new List<test2>();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    test2 t2 = new test2();
                    if (!reader.IsDBNull(0))
                    {
                        t2.id=reader.GetInt32(0);
                    }
                    tt2.Add(t2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int year = System.DateTime.Now.Year;
            string sql = "select * from "+" cap"+year;
            MessageBox.Show(sql);
        }

        public class StudentListEquality2 : IEqualityComparer<NetworkStatus>
        {
            public bool Equals(NetworkStatus o, NetworkStatus k)
            {
                if (o.DeviceId == k.DeviceId)
                {

                    return o.Versions == k.Versions;
                }
                else
                {

                    return false;
                }
            }

            public int GetHashCode(NetworkStatus obj)
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return obj.ToString().GetHashCode();
                }
            }

        }

    }
}
