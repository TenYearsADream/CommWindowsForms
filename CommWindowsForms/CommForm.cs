using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using OPCAutomation;
using CommWindowsForms.DAL;


namespace CommWindowsForms
{
    public partial class CommForm : Form
    {
        public CommForm()
        {
            InitializeComponent();
        }
        DataTable dtAddress;//地址Item,值Value
        // OPCItems MyItems;
        OPCServer MyOpcServer; //定义OPCServer           
        OPCGroup MyOpcGroup; //定义组           
        //OPCItem MyOpcItem1; //Item            
        //OPCItem MyOpcItem2; //值         
        long[] ServerHandle = new long[2]; //Item的句柄 

        Data_Heat data_heat = new Data_Heat();

        private void CommForm_Load(object sender, EventArgs e)
        {
            //1读服务器与地址值
            this.ReadAddress();

            try
            {
                //2连接OPC
                MyOpcServer = new OPCServer();
                MyOpcServer.Connect("OPC.SimaticNet", dtAddress.Rows[0]["Item"].ToString().Trim());//服务器名或者IP地址
                //MyOpcServer.Connect("OPCServer.WinCC", "192.168.1.12");//服务器名或者IP地址
                MyOpcGroup = MyOpcServer.OPCGroups.Add("MyGroup1");

                {
                    MyOpcServer.OPCGroups.DefaultGroupIsActive = true; //激活组
                    MyOpcServer.OPCGroups.DefaultGroupDeadband = 0;  //死区值，设为0
                    MyOpcServer.OPCGroups.DefaultGroupUpdateRate = 1000; //默认族群的刷新频率为200ms

                    MyOpcGroup.UpdateRate = 100; //
                    MyOpcGroup.IsSubscribed = true; // 使用订阅功能，可以异步，默认为false
                }
            }

            catch (Exception ex)
            {
                Common.RecordCommLog(ex);
            }
            //3添加地址值
            this.AddGroupItems();
            
            //值改变出发的动作
            //  MyGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(GroupDataChange);
        }

        
        /// <summary>
        /// 1读服务器与地址值
        /// </summary>
        private void ReadAddress()
        {
            #region  读Excel

            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory + @"\OPC.xls" + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1;'";
            OleDbConnection OleConn = new OleDbConnection(strConn);
            OleConn.Open();
            String sql = "SELECT * FROM  [opc$]";//可是更改Sheet名称，比如sheet2，等等    
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
            DataSet OleDsExcle = new DataSet();
            OleDaExcel.Fill(OleDsExcle, "01");

            #endregion

            //添加Value列
            dtAddress = OleDsExcle.Tables[0];
            dtAddress.Columns.Add(new DataColumn("Value", typeof(string)));
            BindAddressData(dtAddress);
        }   
        private void BindAddressData(DataTable dt)
        {
            bsAddress.DataSource = dt;
            dgvAddress.DataSource = bsAddress;
            dgvAddress.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvAddress.Columns[0].Width = 50;
            dgvAddress.Columns[1].Width = 250;
            dgvAddress.Columns[2].Width = 150;
        }
       
        
        /// <summary>
        /// 3添加地址值
        /// </summary>
        private void AddGroupItems()
        {
            for (int i = 1; i <= dtAddress.Rows.Count; i++)
            {
                MyOpcGroup.OPCItems.AddItem(dtAddress.Rows[i]["Item"].ToString().Trim(), i);
            }
        }

        /// <summary>
        /// 手动刷新测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
        //    Object ItemValues;
        //    Object Qualities;
        //    Object TimeStamps;
        ////    MyOpcItem1.Read(1, out ItemValues, out Qualities, out TimeStamps);
            //string STR = MyOpcGroup.OPCItems.Item(1).Value;
            //string STR1 = dtAddress.Rows[1]["Item"].ToString();
            //tbValue.Text = STR1;
            this.ShowValue();
        }

        
        /// <summary>
        /// 时钟触发 读数据动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrComm_Tick(object sender, EventArgs e)
        {
            //4显示Value  OPC to dtAddress
            this.ShowValue();

            //5.1数据存入Heat变量 dtAddress to Data_Heat 
            data_heat.OpcToHeat(dtAddress);
            //5.2保存表 Data_Heat  to Main
            data_heat.SaveNowEafPlc();
        }
        /// <summary>
        /// 5.3保存表 Data_Heat  to Line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLine_Tick(object sender, EventArgs e)
        {
            
         //   data_heat.SaveLine();
        }

        
        /// <summary>
        /// 4显示Value
        /// </summary>
        private void ShowValue()
        {
            //Random rd = new Random();
            for (int i = 1; i < dtAddress.Rows.Count; i++)
            {
                //dtAddress.Rows[i]["Value"] = rd.Next(0, 10);
                dtAddress.Rows[i]["Value"] = MyOpcGroup.OPCItems.Item(i).Value;
            }
        }

      
    }
}
