using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CommWindowsForms.DAL
{
   public class Data_Heat
    {
       OpcToSql opctosql= new OpcToSql();

        #region 公有变量
        public string AA = "";   //冶炼状态
        public string AB = "";
        public string AC = "";
        public string AD = "";
        public string AE = "";
        public string AF = "";
        public string AG = "";
        #endregion

        public void OpcToHeat(DataTable dt)
        {
            AA = dt.Rows[1]["Value"].ToString();
            AB = dt.Rows[2]["Value"].ToString();
            AC = dt.Rows[3]["Value"].ToString();
            AD = dt.Rows[4]["Value"].ToString();
            AE = dt.Rows[5]["Value"].ToString();
            AF = dt.Rows[6]["Value"].ToString();
            AG = dt.Rows[7]["Value"].ToString();
        }



        public void SaveNowEafPlc()
        {
            DataTable dt = opctosql.GetNowEafPlc();
           
            dt.Rows[0][1] = AA;
            dt.Rows[0][2] = AB;
            dt.Rows[0][3] = AC;
            dt.Rows[0][4] = AD;
            dt.Rows[0][5] = AE;
            dt.Rows[0][6] = AF;
            dt.Rows[0][7] = AG;
            opctosql.SaveNowEafPlc(dt);
        }

        public void SaveLine()
        {
            DataTable dt = opctosql.GetLine();
            
            DataRow row = dt.NewRow();
            row[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            row[1] = AA;
            row[2] = AB;
            row[3] = AC;
            row[4] = AD;
            row[5] = AE;
            row[6] = AF;
            row[7] = AG;
            dt.Rows.Add(row);
            opctosql.SaveLine(dt);
        }

        public void SaveMain()
        {
            if (true)//炉号改变
            {
                //保存Main
                //创建新的Line
            }   
        }

  
    }

     
}
