using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
namespace Test
{
    public static class dbsHelper
    {
        static string connstring = "DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=IT214;PASSWORD=student";
        static OracleConnection conn;
        static OracleCommand comm;
        static OracleDataAdapter da;
        static DataSet ds;
        public static void OpenConn()
        {
            conn = new OracleConnection(connstring);
            conn.Open();
        }
        public static DataSet getDataSet(string command)
        {
            ds = new DataSet();
            try
            {
                OpenConn();
                comm = new OracleCommand(command, conn);
                da = new OracleDataAdapter(comm);
                da.Fill(ds);
                System.Console.Write("hello");
            }

            catch (Exception e)
            {
                System.Console.WriteLine("||  SQL ERROR !" + e.Message);
            }
            return ds;
        }
        public static DataSet getDataSet2(String command)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connstring))
                {
                    OracleCommand cmd = new OracleCommand(command, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("||  SQL ERROR !" + ex.Message);
                return null;
            }
        }
        public static DataTable getDataTable2(String command)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connstring))
                {
                    OracleCommand cmd = new OracleCommand(command, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("||  SQL ERROR !" + ex.Message);
                return null;
            }
        }
        public static Object ExecuteCommand(string command)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connstring))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand(command, con);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("||  SQL ERROR !" + ex.Message);
                return null;
            }
        }
        public static int SendMsg(int active_user_test,int active_chat,String msg)
        {
            comm = new OracleCommand("SENDMSG");
            comm.CommandType = CommandType.StoredProcedure;
            comm.AddToStatementCache = false;
            OracleParameter a = new OracleParameter();
            OracleParameter b = new OracleParameter();
            OracleParameter c = new OracleParameter();
            a.ParameterName = "sender"; a.DbType = DbType.Int32; a.Value = active_user_test; comm.Parameters.Add(a);
            b.ParameterName = "roomid"; b.DbType = DbType.Int32; b.Value = active_chat; comm.Parameters.Add(b);
            c.ParameterName = "msg"; c.DbType = DbType.String; c.Value = msg; comm.Parameters.Add(c);
            comm.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        OpenConn();
                        comm.Connection = conn;
                        return comm.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("||  SQL ERROR !" + e.Message);
                        return 0;
                    }
        }
        public static int createDM(int u1, int u2)
        {
            comm = new OracleCommand("CREATEDM");
            comm.CommandType = CommandType.StoredProcedure;
            comm.AddToStatementCache = false;
            OracleParameter a = new OracleParameter();
            OracleParameter b = new OracleParameter();
            OracleParameter c = new OracleParameter();
            a.ParameterName = "name"; a.DbType = DbType.String; comm.Parameters.Add(a);
            b.ParameterName = "uuid1"; b.DbType = DbType.Int32; b.Value = u1; comm.Parameters.Add(b);
            c.ParameterName = "uuid2"; c.DbType = DbType.Int32; c.Value = u2; comm.Parameters.Add(c);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                OpenConn();
                comm.Connection = conn;
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("||  SQL ERROR !" + e.Message);
                return 0;
            }
        }
        public static int createROOM(string name,int u1)
        {
            comm = new OracleCommand("CREATEROOM");
            comm.CommandType = CommandType.StoredProcedure;
            comm.AddToStatementCache = false;
            OracleParameter a = new OracleParameter();
            OracleParameter b = new OracleParameter();
            OracleParameter c = new OracleParameter();
            a.ParameterName = "name"; a.DbType = DbType.String; a.Value = name; comm.Parameters.Add(a);
            b.ParameterName = "createrid"; b.DbType = DbType.Int32; b.Value = u1; comm.Parameters.Add(b);

            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                OpenConn();
                comm.Connection = conn;
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("||  SQL ERROR !" + e.Message);
                return 0;
            }
        }
        public static int AddUser(int user, int chat)
        {
            comm = new OracleCommand("ADDUSER");
            comm.CommandType = CommandType.StoredProcedure;
            comm.AddToStatementCache = false;
            OracleParameter a = new OracleParameter();
            OracleParameter b = new OracleParameter();
            OracleParameter c = new OracleParameter();
            a.ParameterName = "userid"; a.DbType = DbType.Int32; a.Value = user; comm.Parameters.Add(a);
            b.ParameterName = "roomid"; b.DbType = DbType.Int32; b.Value = chat; comm.Parameters.Add(b);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                OpenConn();
                comm.Connection = conn;
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("||  SQL ERROR !" + e.Message);
                return 0;
            }
        }

        public static string getUserName(string UUID)
        {
            return (string)dbsHelper.ExecuteCommand("select NAME from USERS where UUID =" + UUID);
        }
        public static string getIsGroup(string RUID)
        {
            return (string)dbsHelper.ExecuteCommand("select ISGROUP from ROOMS where RUID =" + RUID).ToString();
        }

    }
}
