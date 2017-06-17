using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DAL.CADB
{
    public class DBConnection
    {
        public MySqlConnection GetConnectionObj()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["CADBConnectionString"].ConnectionString;
            MySqlConnection myConn = new MySqlConnection(strConnection);
            return myConn;
        }
        public void CloseConnection(MySqlConnection myconn)
        {
            myconn.Close();
        }
        public MySqlDataReader GetData(MySqlConnection myconn, string strSQL)
        {
            myconn.Open();
            MySqlCommand myCommand= myconn.CreateCommand();
            myCommand.CommandText = strSQL;
            MySqlDataReader myReader = myCommand.ExecuteReader();
            return myReader;
        }

        public void NewTest()
        {
            string strSQL;
            strSQL = "SELECT * from site_lst";
            MySqlConnection myConn = GetConnectionObj();
            MySqlDataReader myReader = GetData(myConn, strSQL);
            while (myReader.Read())
            {
                Console.WriteLine("Site ID:{0} and Site Name is: {1}", myReader["site_id"], myReader["name"]);
            }
            CloseConnection(myConn);
        }
    }
}
