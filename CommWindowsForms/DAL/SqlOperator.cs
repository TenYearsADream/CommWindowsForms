using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommWindowsForms.DAL
{
    public class SqlOperator
    {
        private String _serverName = "CqmsServer";

        public SqlOperator()
        {
        }

        public SqlOperator(String serverName)
        {
            _serverName = serverName.Trim();
        }

        public String ServerName
        {
            set
            {
                _serverName = value.Trim();
            }
        }

        public DataTable ExecuteFill(string strSql, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                try
                {
                    SqlCommand commad = new SqlCommand(strSql, conn);
                    commad.CommandTimeout = 90;//将默认连接SQL响应时间30S改为90s
                    if (paras != null)
                    {
                        commad.Parameters.AddRange(paras);
                    }
                    commad.CommandType = CommandType.Text;
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = commad;

                    DataTable dtl = new DataTable();
                    adapter.FillSchema(dtl, SchemaType.Source);
                    adapter.Fill(dtl);

                    return dtl;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public int ExecuteNonQuery(string strSql, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                try
                {
                    SqlCommand commad = new SqlCommand(strSql, conn);
                    if (paras != null)
                    {
                        commad.Parameters.AddRange(paras);
                    }
                    commad.CommandType = CommandType.Text;
                    conn.Open();
                    int result = commad.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public object ExecuteScalar(string strSql, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                try
                {
                    SqlCommand commad = new SqlCommand(strSql, conn);
                    if (paras != null)
                    {
                        commad.Parameters.AddRange(paras);
                    }
                    commad.CommandType = CommandType.Text;
                    conn.Open();
                    object result = commad.ExecuteScalar();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public Byte[] ExecuteReader(string strSql, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                try
                {
                    SqlCommand commad = new SqlCommand(strSql, conn);
                    if (paras != null)
                    {
                        commad.Parameters.AddRange(paras);
                    }
                    commad.CommandType = CommandType.Text;
                    conn.Open();

                    SqlDataReader reader = commad.ExecuteReader(CommandBehavior.SequentialAccess);
                    if (reader.Read())
                    {
                        long bytesSize = reader.GetBytes(0, 0, null, 0, 0);
                        Byte[] blob = new Byte[bytesSize];
                        reader.GetBytes(0, 0, blob, 0, blob.Length);

                        return blob;
                    }
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public int ExecuteProcedure(string procedureName, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                SqlCommand commad = new SqlCommand();
                commad.Connection = conn;
                commad.CommandTimeout = 5;
                commad.CommandText = procedureName;
                commad.CommandType = CommandType.StoredProcedure;
                if (paras != null)
                {
                    commad.Parameters.AddRange(paras);
                }
                try
                {
                    conn.Open();
                    int result = commad.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    commad.ResetCommandTimeout();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public DataSet ExecuteProcedureOutputCursor(string procedureName, SqlParameter[] paras)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                try
                {
                    SqlCommand commad = new SqlCommand(procedureName, conn);
                    if (paras != null)
                    {
                        commad.Parameters.AddRange(paras);
                    }
                    commad.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = commad;

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public int Save1(string strSql, DataTable dtSource)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                try
                {
                    //    da.FillSchema(dt, SchemaType.Source);
                    //    //da.Fill(dt);

                    //    dt.Merge(dtSource);
                    int result = da.Update(dtSource);

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public int Save(string strSql, DataTable dtSource)
        {
            using (SqlConnection conn = DbConnection.GetDataBaseConnection(_serverName))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                try
                {
                    da.FillSchema(dt, SchemaType.Source);
                    da.Fill(dt);

                    dt.Merge(dtSource);
                    int result = da.Update(dt);

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }


        internal int Save(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }

       

    }

