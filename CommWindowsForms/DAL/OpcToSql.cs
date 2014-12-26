using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CommWindowsForms.DAL
{
    public class OpcToSql
    {
        public DataTable GetNowEafPlc()
        {
            StringBuilder strBuilder = new StringBuilder("SELECT * FROM Now_Plc");

            SqlOperator operation = new SqlOperator();
            return operation.ExecuteFill(strBuilder.ToString(), null);
        }

        public Int32 SaveNowEafPlc(DataTable dt)
        {
            StringBuilder strBuilder = new StringBuilder("SELECT * FROM Now_Plc");

            SqlOperator operation = new SqlOperator();
            return operation.Save(strBuilder.ToString(), dt);
        }


        public DataTable GetLine()
        {
            StringBuilder strBuilder = new StringBuilder("SELECT * FROM Line");

            SqlOperator operation = new SqlOperator();
            return operation.ExecuteFill(strBuilder.ToString(), null);
        }

        public Int32 SaveLine(DataTable dt)
        {
            StringBuilder strBuilder = new StringBuilder("SELECT * FROM Line");

            SqlOperator operation = new SqlOperator();
            return operation.Save(strBuilder.ToString(), dt);
        }
    }
}
