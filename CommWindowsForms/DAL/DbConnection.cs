using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using UstbMoll.MayaProfile;

namespace CommWindowsForms.DAL
{
    public struct ServerInfo
    {
        public String IPAddress;

        public String DataBaseName;
        public String UserName;
        public String Password;
    }

    public class DbConnection
    {
        private static readonly String m_settingFile = Environment.CurrentDirectory + @"\ServerSetting.ini";

        private static ServerInfo GetServerSettings(String serverName)
        {
            ServerInfo server;

            IniFile dbFile = new IniFile(m_settingFile);

            server.IPAddress = dbFile.GetString(serverName, "IPAddress", "");

            server.DataBaseName = dbFile.GetString(serverName, "DBName", "");
            server.UserName = dbFile.GetString(serverName, "UserName", "");
            server.Password = dbFile.GetString(serverName, "Password", "");

            return server;
        }

        private static String CreateConnectString(String serverName)
        {
            ServerInfo server = GetServerSettings(serverName);

            return CreateConnectString(server);
        }

        private static String CreateConnectString(ServerInfo server)
        {
            if (server.IPAddress == null)
                return null;

            StringBuilder connBuilder = new StringBuilder("Persist Security Info=False");

            connBuilder.Append(";User ID=");
            connBuilder.Append(server.UserName);
            connBuilder.Append(";Password=");
            connBuilder.Append(server.Password);
            connBuilder.Append(";Initial Catalog=");
            connBuilder.Append(server.DataBaseName);
            connBuilder.Append(";Data Source=");
            connBuilder.Append(server.IPAddress);




            return connBuilder.ToString();
        }

        public static SqlConnection GetDataBaseConnection()
        {
            try
            {
                string strConn = CreateConnectString("CqmsServer");
                SqlConnection conn = new SqlConnection(strConn);
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static SqlConnection GetDataBaseConnection(String serverName)
        {
            try
            {
                string strConn = CreateConnectString(serverName);
                SqlConnection conn = new SqlConnection(strConn);
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
