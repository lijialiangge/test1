
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class DB
    {
        //public static string SqlCon = @"Data Source=.;Initial Catalog=DRAQ127;User ID=sa;Password=ok;";
        public static string SqlCon = @"Data Source=.;Initial Catalog=PCTron;User ID=sa;Password=ok;";

        public List<test> test(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<test> u1 = new List<test>(); //新建一个User类的集合
                if (dr.HasRows)
                {
                    while (dr.Read())//遍历dr
                    {
                        test u0 = new test(); //临时User类变量u0

                        //把查询的当前记录各字段值赋值给对于的u0的属性
                        if (!dr.IsDBNull(0))
                        {
                            u0.devcieid = dr.GetString(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            u0.AlarmName = dr.GetString(1);
                        }

                        u1.Add(u0);//把有数据的u0加入到User类的集合
                    }

                    while (dr.NextResult())//遍历dr
                    {
                        while (dr.Read())//遍历dr
                        {
                            test1 u0 = new test1(); //临时User类变量u0

                            //把查询的当前记录各字段值赋值给对于的u0的属性

                            u0.devcieid = dr.GetString(0);

                            u0.AlarmName = dr.GetString(1);

                        }
                        //u1.Add(u0);//把有数据的u0加入到User类的集合
                    }
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 执行查询，返回DataTable对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataTable对象</returns>
        public  DataTable GetTable(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            }
            return dt;
        }




        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql">所用的sql语句</param>
        /// <param name="param">可变，可以传参也可以不传参数</param>
        /// <returns></returns>
        public DataSet test2(string sql, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(SqlCon))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                {
                    //添加参数
                    adapter.SelectCommand.Parameters.AddRange(param);
                    //1.打开链接，如果连接没有打开，则它给你打开；如果打开，就算了
                    //2.去执行sql语句，读取数据库
                    //3.sqlDataReader,把读取到的数据填充到内存表中
                    adapter.Fill(dt);
                    adapter.Fill(ds);
                }
                con.Close();
            }

            return ds;
        }

        public List<Monthly_Output_Model> monthly_output_model(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Monthly_Output_Model> u1 = new List<Monthly_Output_Model>(); //新建一个User类的集合
                if (dr.HasRows)
                {
                    while (dr.Read())//遍历dr
                    {
                        Monthly_Output_Model u0 = new Monthly_Output_Model(); //临时User类变量u0

                        //把查询的当前记录各字段值赋值给对于的u0的属性
                        if (!dr.IsDBNull(0))
                        {
                            u0.Q127_100 = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            u0.Q127_150 = dr.GetInt32(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            u0.Q127_220 = dr.GetInt32(2);
                        }
                        if (!dr.IsDBNull(3))
                        {
                            u0.Q127_330 = dr.GetInt32(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            u0.Q127_470 = dr.GetInt32(4);
                        }
                        if (!dr.IsDBNull(5))
                        {
                            u0.A127_R47 = dr.GetInt32(5);
                        }
                        if (!dr.IsDBNull(6))
                        {
                            u0.A127_1R0 = dr.GetInt32(6);
                        }
                        if (!dr.IsDBNull(7))
                        {
                            u0.A127_1R5 = dr.GetInt32(7);
                        }
                        if (!dr.IsDBNull(8))
                        {
                            u0.A127_2R2 = dr.GetInt32(8);
                        }
                        if (!dr.IsDBNull(9))
                        {
                            u0.A127_3R3 = dr.GetInt32(9);
                        }
                        if (!dr.IsDBNull(10))
                        {
                            u0.A127_4R7 = dr.GetInt32(10);
                        }
                        if (!dr.IsDBNull(11))
                        {
                            u0.A127_6R8 = dr.GetInt32(11);
                        }
                        if (!dr.IsDBNull(12))
                        {
                            u0.A127_8R2 = dr.GetInt32(12);
                        }
                        if (!dr.IsDBNull(13))
                        {
                            u0.A127_100 = dr.GetInt32(13);
                        }
                        if (!dr.IsDBNull(14))
                        {
                            u0.A127_150 = dr.GetInt32(14);
                        }
                        if (!dr.IsDBNull(15))
                        {

                            u0.A127_220 = dr.GetInt32(15);
                        }
                        if (!dr.IsDBNull(16))
                        {
                            u0.A127_330 = dr.GetInt32(16);
                        }
                        if (!dr.IsDBNull(17))
                        {
                            u0.A127_470 = dr.GetInt32(17);
                        }
                        if (!dr.IsDBNull(18))
                        {
                            u0.A127_680 = dr.GetInt32(18);
                        }
                        if (!dr.IsDBNull(19))
                        {
                            u0.A127_820 = dr.GetInt32(19);
                        }
                        if (!dr.IsDBNull(20))
                        {
                            u0.A127_101 = dr.GetInt32(20);
                        }
                        if (!dr.IsDBNull(21))
                        {
                            u0.A127_151 = dr.GetInt32(21);
                        }
                        if (!dr.IsDBNull(22))
                        {
                            u0.A127_221 = dr.GetInt32(22);
                        }
                        if (!dr.IsDBNull(23))
                        {
                            u0.A127_331 = dr.GetInt32(23);
                        }
                        if (!dr.IsDBNull(24))
                        {
                            u0.A127_471 = dr.GetInt32(24);
                        }
                        if (!dr.IsDBNull(25))
                        {
                            u0.A127_681 = dr.GetInt32(25);
                        }
                        if (!dr.IsDBNull(26))
                        {
                            u0.A127_821 = dr.GetInt32(26);
                        }
                        if (!dr.IsDBNull(27))
                        {

                            u0.A127_102 = dr.GetInt32(27);
                        }
                        if (!dr.IsDBNull(28))
                        {
                            u0.A125_R47 = dr.GetInt32(28);
                        }
                        if (!dr.IsDBNull(29))
                        {
                            u0.A125_1R0 = dr.GetInt32(29);
                        }
                        if (!dr.IsDBNull(30))
                        {
                            u0.A125_1R5 = dr.GetInt32(30);
                        }
                        if (!dr.IsDBNull(31))
                        {
                            u0.A125_2R2 = dr.GetInt32(31);
                        }
                        if (!dr.IsDBNull(32))
                        {
                            u0.A125_3R3 = dr.GetInt32(32);
                        }
                        if (!dr.IsDBNull(33))
                        {
                            u0.A125_4R7 = dr.GetInt32(33);
                        }
                        if (!dr.IsDBNull(34))
                        {
                            u0.A125_6R8 = dr.GetInt32(34);
                        }
                        if (!dr.IsDBNull(35))
                        {
                            u0.A125_8R2 = dr.GetInt32(35);
                        }
                        if (!dr.IsDBNull(36))
                        {
                            u0.A125_100 = dr.GetInt32(36);
                        }
                        if (!dr.IsDBNull(37))
                        {

                            u0.A125_150 = dr.GetInt32(37);
                        }
                        if (!dr.IsDBNull(38))
                        {
                            u0.A125_220 = dr.GetInt32(38);
                        }
                        if (!dr.IsDBNull(39))
                        {
                            u0.A125_330 = dr.GetInt32(39);
                        }
                        if (!dr.IsDBNull(40))
                        {
                            u0.A125_470 = dr.GetInt32(40);
                        }
                        if (!dr.IsDBNull(41))
                        {
                            u0.A125_680 = dr.GetInt32(41);
                        }
                        if (!dr.IsDBNull(42))
                        {
                            u0.A125_820 = dr.GetInt32(42);
                        }
                        if (!dr.IsDBNull(43))
                        {
                            u0.A125_101 = dr.GetInt32(43);
                        }
                        if (!dr.IsDBNull(44))
                        {
                            u0.A125_151 = dr.GetInt32(44);
                        }
                        if (!dr.IsDBNull(45))
                        {
                            u0.A125_221 = dr.GetInt32(45);
                        }
                        if (!dr.IsDBNull(46))
                        {
                            u0.A125_331 = dr.GetInt32(46);
                        }
                        if (!dr.IsDBNull(47))
                        {


                            u0.A125_471 = dr.GetInt32(47);
                        }
                        if (!dr.IsDBNull(48))
                        {
                            u0.A125_681 = dr.GetInt32(48);
                        }
                        if (!dr.IsDBNull(49))
                        {

                            u0.A125_821 = dr.GetInt32(49);
                        }
                        if (!dr.IsDBNull(50))
                        {
                            u0.A125_102 = dr.GetInt32(50);
                        }
                        if (!dr.IsDBNull(51))
                        {
                            u0.A124_R47 = dr.GetInt32(51);
                        }
                        if (!dr.IsDBNull(52))
                        {
                            u0.A124_1R0 = dr.GetInt32(52);
                        }
                        if (!dr.IsDBNull(53))
                        {
                            u0.A124_1R5 = dr.GetInt32(53);
                        }
                        if (!dr.IsDBNull(54))
                        {
                            u0.A124_2R2 = dr.GetInt32(54);
                        }
                        if (!dr.IsDBNull(55))
                        {
                            u0.A124_3R3 = dr.GetInt32(55);
                        }
                        if (!dr.IsDBNull(56))
                        {
                            u0.A124_4R7 = dr.GetInt32(56);
                        }
                        if (!dr.IsDBNull(57))
                        {

                            u0.A124_6R8 = dr.GetInt32(57);
                        }
                        if (!dr.IsDBNull(58))
                        {
                            u0.A124_8R2 = dr.GetInt32(58);
                        }
                        if (!dr.IsDBNull(59))
                        {
                            u0.A124_100 = dr.GetInt32(59);
                        }
                        if (!dr.IsDBNull(60))
                        {
                            u0.A124_150 = dr.GetInt32(60);
                        }
                        if (!dr.IsDBNull(61))
                        {
                            u0.A124_220 = dr.GetInt32(61);
                        }
                        if (!dr.IsDBNull(62))
                        {
                            u0.A124_330 = dr.GetInt32(62);
                        }
                        if (!dr.IsDBNull(63))
                        {
                            u0.A124_470 = dr.GetInt32(63);
                        }
                        if (!dr.IsDBNull(64))
                        {
                            u0.A124_680 = dr.GetInt32(64);
                        }
                        if (!dr.IsDBNull(65))
                        {
                            u0.A124_820 = dr.GetInt32(65);
                        }
                        if (!dr.IsDBNull(66))
                        {
                            u0.A124_101 = dr.GetInt32(66);
                        }
                        if (!dr.IsDBNull(67))
                        {

                            u0.A124_151 = dr.GetInt32(67);
                        }
                        if (!dr.IsDBNull(68))
                        {
                            u0.A124_221 = dr.GetInt32(68);
                        }
                        if (!dr.IsDBNull(69))
                        {
                            u0.A124_331 = dr.GetInt32(69);
                        }
                        if (!dr.IsDBNull(70))
                        {
                            u0.A124_471 = dr.GetInt32(70);
                        }
                        if (!dr.IsDBNull(71))
                        {
                            u0.A124_681 = dr.GetInt32(71);
                        }
                        if (!dr.IsDBNull(72))
                        {
                            u0.A124_821 = dr.GetInt32(72);
                        }
                        if (!dr.IsDBNull(73))
                        {
                            u0.A124_102 = dr.GetInt32(73);
                        }


                        u1.Add(u0);//把有数据的u0加入到User类的集合
                    }

                    while (dr.NextResult())//遍历dr
                    {
                        while (dr.Read())//遍历dr
                        {
                            test1 u0 = new test1(); //临时User类变量u0

                            //把查询的当前记录各字段值赋值给对于的u0的属性

                            u0.devcieid = dr.GetString(0);

                            u0.AlarmName = dr.GetString(1);

                        }
                        //u1.Add(u0);//把有数据的u0加入到User类的集合
                    }
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        public List<Save_Monthly_OutputAndNG> save_monthly_outputAndNG(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Save_Monthly_OutputAndNG> u1 = new List<Save_Monthly_OutputAndNG>(); //新建一个User类的集合
                if (dr.HasRows)
                {
                    while (dr.Read())//遍历dr
                    {
                        Save_Monthly_OutputAndNG u0 = new Save_Monthly_OutputAndNG(); //临时User类变量u0

                        //把查询的当前记录各字段值赋值给对于的u0的属性
                        if (!dr.IsDBNull(0))
                        {
                            u0.ID = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            u0.Model = dr.GetString(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            u0.Output_Monthly01 = dr.GetInt32(2);
                        }
                        if (!dr.IsDBNull(3))
                        {
                            u0.Output_Monthly02 = dr.GetInt32(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            u0.Output_Monthly03 = dr.GetInt32(4);
                        }
                        if (!dr.IsDBNull(5))
                        {
                            u0.Output_Monthly04 = dr.GetInt32(5);
                        }
                        if (!dr.IsDBNull(6))
                        {
                            u0.Output_Monthly05 = dr.GetInt32(6);
                        }
                        if (!dr.IsDBNull(7))
                        {
                            u0.Output_Monthly06 = dr.GetInt32(7);
                        }
                        if (!dr.IsDBNull(8))
                        {
                            u0.Output_Monthly07 = dr.GetInt32(8);
                        }
                        if (!dr.IsDBNull(9))
                        {
                            u0.Output_Monthly08 = dr.GetInt32(9);
                        }
                        if (!dr.IsDBNull(10))
                        {
                            u0.Output_Monthly09 = dr.GetInt32(10);
                        }
                        if (!dr.IsDBNull(11))
                        {
                            u0.Output_Monthly10 = dr.GetInt32(11);
                        }
                        if (!dr.IsDBNull(12))
                        {
                            u0.Output_Monthly11 = dr.GetInt32(12);
                        }
                        if (!dr.IsDBNull(13))
                        {
                            u0.Output_Monthly12 = dr.GetInt32(13);
                        }
                        if (!dr.IsDBNull(14))
                        {
                            u0.NG_Monthly01 = dr.GetInt32(14);
                        }
                        if (!dr.IsDBNull(15))
                        {

                            u0.NG_Monthly02 = dr.GetInt32(15);
                        }
                        if (!dr.IsDBNull(16))
                        {
                            u0.NG_Monthly03 = dr.GetInt32(16);
                        }
                        if (!dr.IsDBNull(17))
                        {
                            u0.NG_Monthly04 = dr.GetInt32(17);
                        }
                        if (!dr.IsDBNull(18))
                        {
                            u0.NG_Monthly05 = dr.GetInt32(18);
                        }
                        if (!dr.IsDBNull(19))
                        {
                            u0.NG_Monthly06 = dr.GetInt32(19);
                        }
                        if (!dr.IsDBNull(20))
                        {
                            u0.NG_Monthly07 = dr.GetInt32(20);
                        }
                        if (!dr.IsDBNull(21))
                        {
                            u0.NG_Monthly08 = dr.GetInt32(21);
                        }
                        if (!dr.IsDBNull(22))
                        {
                            u0.NG_Monthly09 = dr.GetInt32(22);
                        }
                        if (!dr.IsDBNull(23))
                        {
                            u0.NG_Monthly10 = dr.GetInt32(23);
                        }
                        if (!dr.IsDBNull(24))
                        {
                            u0.NG_Monthly11 = dr.GetInt32(24);
                        }
                        if (!dr.IsDBNull(25))
                        {
                            u0.NG_Monthly12 = dr.GetInt32(25);
                        }


                        u1.Add(u0);//把有数据的u0加入到User类的集合
                    }

                    while (dr.NextResult())//遍历dr
                    {
                        while (dr.Read())//遍历dr
                        {
                            test1 u0 = new test1(); //临时User类变量u0

                            //把查询的当前记录各字段值赋值给对于的u0的属性

                            u0.devcieid = dr.GetString(0);

                            u0.AlarmName = dr.GetString(1);

                        }
                        //u1.Add(u0);//把有数据的u0加入到User类的集合
                    }
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        public List<KeyValue_OutputAndNG> select_monthlyoutput(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<KeyValue_OutputAndNG> u1 = new List<KeyValue_OutputAndNG>(); //新建一个User类的集合
                if (dr.HasRows)
                {
                    while (dr.Read())//遍历dr
                    {
                        KeyValue_OutputAndNG u0 = new KeyValue_OutputAndNG(); //临时User类变量u0

                        //把查询的当前记录各字段值赋值给对于的u0的属性
                        if (!dr.IsDBNull(0))
                        {
                            u0.output = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            u0.NG = dr.GetInt32(1);



                            u1.Add(u0);//把有数据的u0加入到User类的集合
                        }


                    }
                    //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                }
                return u1;

            }

        }


        public int ExecuteNonQuery(string safeSql)
        {
            using (SqlConnection Connection = new SqlConnection(SqlCon))
            {
                Connection.Open();
                SqlTransaction trans = Connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(safeSql, Connection);
                    cmd.Transaction = trans;

                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {

                    return 0;
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        public  DataTable GetTable(string strSQL)
        {
            return GetTable(strSQL, null);
        }
        public  DataTable GetTable(string strSQL, SqlParameter[] pas)
        {
            return GetTable(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataTable对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataTable对象</returns>



    }
}
