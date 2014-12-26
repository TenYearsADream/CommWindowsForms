using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace CommWindowsForms.DAL
{

        public delegate void DataSetFilledEventHandler(object sender, DataSetFilledEventArgs e);

        public class DataSetFilledEventArgs : EventArgs
        {
            private DataSet _dataSet;

            public DataSetFilledEventArgs(DataSet filledDataSet)
            {
                this._dataSet = filledDataSet;
            }

            public DataSet FilledDataSet
            {
                get
                {
                    return _dataSet;
                }
            }
        }

        public delegate void DataTableFilledEventHandler(object sender, DataTableFilledEventArgs e);

        public class DataTableFilledEventArgs : EventArgs
        {
            private DataTable _dataTable;

            public DataTableFilledEventArgs(DataTable filledDataTable)
            {
                this._dataTable = filledDataTable;
            }

            public DataTable FilledDataTable
            {
                get
                {
                    return _dataTable;
                }
            }
        }

        public class Common
        {
            public static void RecordCommLog(Exception ex)
            {
                String logFile = Environment.CurrentDirectory + @"\EventLog" + DateTime.Today.ToString("yyMM") + ".log";
                try
                {
                    StreamWriter sw = new StreamWriter(logFile, true);
                    sw.WriteLine("\r\n========================================================\r\n");
                   // sw.WriteLine(GetServerCurrentSysTime().ToString("yyyy-MM-dd HH:mm:ss") + " 发生错误:\r\n");
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine("\r\n========================================================\r\n");
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                    return;
                }
            }


            /*

            //sever2005 获取时间函数  当前程序有使用
            public static DateTime GetServerCurrentSysTime()
            {
                String strSql = "SELECT getdate()";

                DateTime nowTime = DateTime.Now;
                SqlOperator operation = new SqlOperator(strSql);
                try
                {
                    Object ob = operation.ExecuteScalar(null);
                    if (ob != null && !Convert.IsDBNull(ob))
                        nowTime = Convert.ToDateTime(ob);
                }
                catch
                {
                }

                return nowTime;
            }
            

            public static String GetCurrentHeat()
            {
                StringBuilder strBuilder = new StringBuilder("SELECT heatno FROM ac_eaf_smelt_info_t ");
                strBuilder.Append(" WHERE startdate = (SELECT MAX(startdate) FROM ac_eaf_smelt_info_t)");

                String heatNo = "0123456789";
                SqlOperator operation = new SqlOperator(strBuilder.ToString());
                Object ob = operation.ExecuteScalar(null);
                if (ob != null && !Convert.IsDBNull(ob))
                    heatNo = ob.ToString();

                return heatNo;
            }

            //Oracle 获取时间函数  当前程序未使用
            public static DateTime GetCurrentSysTime()
            {
                String strSql = "SELECT sysdate FROM dual";

                DateTime nowTime = DateTime.Now;
                SqlOperator operation = new SqlOperator(strSql);
                try
                {
                    Object ob = operation.ExecuteScalar(null);
                    if (ob != null && !Convert.IsDBNull(ob))
                        nowTime = Convert.ToDateTime(ob);
                }
                catch
                {
                }

                return nowTime;
            }

            public static Boolean CanConnect()
            {
                String strSql = "SELECT sysdate FROM dual";

                Boolean isConnected = false;
                SqlOperator operation = new SqlOperator(strSql);
                try
                {
                    Object ob = operation.ExecuteScalar(null);
                    if (ob != null && !Convert.IsDBNull(ob))
                        isConnected = true;
                }
                catch
                {
                    isConnected = false;
                }

                return isConnected;
            }



            public static Boolean ServerCanConnect()
            {
                String strSql = "SELECT getdate()";

                Boolean isConnected = false;
                SqlOperator operation = new SqlOperator(strSql);
                try
                {
                    Object ob = operation.ExecuteScalar(null);
                    if (ob != null && !Convert.IsDBNull(ob))
                        isConnected = true;
                }
                catch
                {
                    isConnected = false;
                }

                return isConnected;
            }
             */

        }

        
    }











