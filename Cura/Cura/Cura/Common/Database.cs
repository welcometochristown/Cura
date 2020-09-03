using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;

namespace Cura.Common
{
    class Database
    {

        public static int MAX_PARAMETER_COUNT
        {
            get
            {
                return 995;
            }
        }

        public static int MAX_UNION_SELECTS
        {
            get
            {
                return 500;
            }
        }

        public static string connection_string
        {
            get
            {
                // return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Settings.Instance.datafilepath + ";Persist Security Info=False;";
                return "Data Source=" + Settings.Instance.datafilepath + ";Version=3;New=True;Compress=True;";
            }
        }

        public static string pcode_connection_string
        {
            get
            {
                int index = Settings.Instance.datafilepath.LastIndexOf("\\");

                return "Data Source=" + Settings.Instance.datafilepath.Substring(0, index+1) + "pcodes.db" + ";Version=3;New=True;Compress=True;";
            }
        }

        public static DataTable ExecutePCodeDatabaseQuery(string query, object[] param = null)
        {
            return ExecuteDatabaseQuery(pcode_connection_string, query, param, QueryType.GENERAL_QUERY);
        }

        public static DataTable ExecuteDatabaseQuery(string query, object[] param = null, bool isInsert = false)
        {
            return ExecuteDatabaseQuery(connection_string, query, param, (isInsert ? QueryType.INSERT_QUERY: QueryType.GENERAL_QUERY));
        }

        #region ExecuteDatabaseQuery [Access DB]

        //public static DataTable ExecuteDatabaseQuery(string connectionstring, string query, object[] param = null, bool isInsert = false)
        //{
        //    //return new DataTable();

        //    OleDbConnection Conn = new OleDbConnection();

        //    Conn.ConnectionString = connectionstring;

        //    Conn.Open();

        //    try
        //    {
        //        OleDbDataReader dr;

        //        if (isInsert)
        //        {
        //            OleDbCommand cmd = Conn.CreateCommand();

        //            cmd.CommandType = System.Data.CommandType.Text;

        //            cmd.CommandText = query;

        //            if (param != null)
        //            {
        //                foreach (object o in param)
        //                {
        //                    cmd.Parameters.AddWithValue("?", o);
        //                }
        //            }

        //            cmd.ExecuteNonQuery();

        //            cmd.CommandText = "SELECT @@IDENTITY";
        //            dr = cmd.ExecuteReader();

        //        }
        //        else
        //        {
        //            OleDbCommand cmd = new OleDbCommand(query, Conn);
        //            dr = cmd.ExecuteReader();
        //        }

        //        DataTable dt = new DataTable();
        //        dt.Load(dr);

        //        Conn.Close();

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Unable execute query", ex);

        //    }

        //}

        #endregion

        public enum QueryType
        {
            GENERAL_QUERY = 0,
            INSERT_QUERY = 1,
            STATEMENT = 2
        }

        public static DataTable ExecuteDatabaseQuery(string connectionstring, string query, object[] param = null, QueryType type = QueryType.GENERAL_QUERY)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader = null;

            //create the connection
            sqlite_conn = new SQLiteConnection(connectionstring);

            string dSource = connectionstring.Split(';')[0].Split('=')[1];
            if (!File.Exists(dSource))
            {
                throw new Exception(String.Format("Data source does not exist {0}", sqlite_conn.DataSource));
            }


            //open it
            sqlite_conn.Open();

            //create a command to execute
            sqlite_cmd = sqlite_conn.CreateCommand();

            //set the query
            sqlite_cmd.CommandText = query;

            //now sort out the paramers
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    object p = param[i];

                    sqlite_cmd.Parameters.AddWithValue("@" + i.ToString(), p);
                }
            }
           
            //check whether we are doing an insert. If so we will need to return the id of the last inserted.
            if (type == QueryType.INSERT_QUERY)
            {
                sqlite_cmd.ExecuteNonQuery();

                SQLiteCommand sqlite_Insert_cmd;

               sqlite_Insert_cmd =  sqlite_conn.CreateCommand();
               sqlite_Insert_cmd.CommandText = "SELECT last_insert_rowid()";

               sqlite_datareader = sqlite_Insert_cmd.ExecuteReader();
            }
            else if (type == QueryType.STATEMENT)
            {
                sqlite_cmd.ExecuteNonQuery();

            }else
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
            }

            //load results into the datatable and hey presto we are done.
            DataTable dt = null;

            if (sqlite_datareader != null)
            {
                dt = new DataTable();
                dt.Load(sqlite_datareader);  // sqlite_datareader.GetSchemaTable();

            }
            //close the connection
            sqlite_conn.Close();

            return dt;

        }

        #region ExecuteDatabaseStatement [Access DB]
        //    public static void ExecuteDatabaseStatement(string statement, object[] param = null)
        //    {

        //        OleDbConnection Conn = new OleDbConnection();

        //        Conn.ConnectionString = connection_string;

        //        Conn.Open();

        //        try
        //        {
        //            OleDbCommand cmd = new OleDbCommand(statement, Conn);

        //            if (param != null)
        //            {
        //                foreach (object o in param)
        //                {
        //                    cmd.Parameters.AddWithValue("?", o);
        //                }
        //            }

        //            cmd.ExecuteNonQuery();

        //            Conn.Close();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Unable execute statement", ex);
        //        }
        //    }
   
        #endregion

        public static void ExecuteDatabaseStatement(string statement, object[] param = null)
        {

            ExecuteDatabaseQuery(connection_string, statement, param, QueryType.STATEMENT);

        }
    }
}
