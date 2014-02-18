using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Devnuggets.Toolkit.Data.MySql
{
    public class MySqlHelper
    {
        public string ConnectionString { get; set; }

        public MySqlHelper(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public void Dispose()
        {

        }

        public DataSet GetDataset(string inputsql)
        {
            using (MySqlConnection cn = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand myAccessCommand = new MySqlCommand(inputsql, cn))
                {
                    myAccessCommand.CommandTimeout = 3600;
                    DataSet ds = new DataSet();
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(myAccessCommand);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
            }

            /*
            using (OdbcConnection cn = new OdbcConnection(System.Configuration.ConfigurationManager.AppSettings["dbconn"]))
            {
                using (OdbcCommand myAccessCommand = new OdbcCommand(inputsql, cn))
                {
                    DataSet ds = new DataSet();
                    OdbcDataAdapter myDataAdapter = new OdbcDataAdapter(myAccessCommand);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
            }
            */
        }


        public DataSet GetDataset(string inputsql, params MySqlParameter[] commandParameters)
        {

            using (MySqlConnection cn = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand myAccessCommand = new MySqlCommand(inputsql, cn))
                {
                    myAccessCommand.CommandTimeout = 3600;
                    DataSet ds = new DataSet();
                    //OdbcParameterCollection c = null;

                    foreach (MySqlParameter p in commandParameters)
                    {
                        if (p != null)
                        {
                            myAccessCommand.Parameters.Add(p);
                        }
                    }

                    //myAccessCommand.Parameters = c;
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(myAccessCommand);
                    myDataAdapter.Fill(ds);
                    return ds;
                }

            }






        }

        public void ExecuteSql(string inputsql, params MySqlParameter[] commandParameters)
        {
            using (MySqlConnection cn = new MySqlConnection(ConnectionString))
            {
                cn.Open();
                MySqlCommand myAccessCommand1 = new MySqlCommand(inputsql, cn);
                foreach (MySqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        myAccessCommand1.Parameters.Add(p);
                    }
                }
                myAccessCommand1.CommandTimeout = 3600;
                myAccessCommand1.ExecuteNonQuery();
                cn.Close();
            }

        }

        public void ExecuteSql(string inputsql)
        {
            using (MySqlConnection cn = new MySqlConnection(ConnectionString))
            {
                cn.Open();
                MySqlCommand myAccessCommand1 = new MySqlCommand(inputsql, cn);
                myAccessCommand1.CommandTimeout = 3600;
                myAccessCommand1.ExecuteNonQuery();
                cn.Close();
            }

        }
    }
}
