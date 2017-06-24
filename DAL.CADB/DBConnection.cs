using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace DAL.CADB
{
    public class DBConnection
    {
        private MySqlConnection MySqlConnObj;
        private string strConnection = ConfigurationManager.ConnectionStrings["CADBConnectionString"].ConnectionString;
        public DBConnection()
        {
            MySqlConnObj = new MySqlConnection(strConnection);
        }
        public MySqlConnection _MySqlConnObj
        {
            get {
                if (MySqlConnObj == null)
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["CADBConnectionString"].ConnectionString;
                    MySqlConnection MySqlConnObj = new MySqlConnection(strConnection);
                }
                //string strConnection = ConfigurationManager.ConnectionStrings["CADBConnectionString"].ConnectionString;
                //MySqlConnection MySqlConnObj = new MySqlConnection(strConnection);
                return MySqlConnObj;
                } 
        }
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
        public MySqlDataReader GetData(string strSQL)
        {
            //myconn.Open();
            //MySqlConnObj = _MySqlConnObj;
            MySqlConnObj.Open();
            MySqlCommand myCommand= MySqlConnObj.CreateCommand();
            myCommand.CommandText = strSQL;
            MySqlDataReader myReader = myCommand.ExecuteReader();
            return myReader;
        }
        public DataTable GetDisconnectedData(string strSQL)
        {
            MySqlConnObj.Open();
            MySqlCommand myCommand = new MySqlCommand(strSQL, MySqlConnObj);
            myCommand.CommandType = CommandType.Text;
            MySqlDataAdapter ad = new MySqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            //CloseConnection(MySqlConnObj);
            MySqlConnObj.Close();
            return dt;
        }
        public void TestWithAdapter()
        {
            string strSQL = "SELECT * FROM site_lst";
            DataTable dt = GetDisconnectedData(strSQL);
            Console.WriteLine("Disconnected Data Sets");
            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine("Site ID:{0} and Site Name is: {1}", dr["site_id"], dr["name"]);
            }
        }
        public void NewTest()
        {
            string strSQL;
            strSQL = "SELECT * from site_lst";
            //MySqlConnection myConn = GetConnectionObj();
            MySqlDataReader myReader = GetData(strSQL);
            while (myReader.Read())
            {
                Console.WriteLine("Site ID:{0} and Site Name is: {1}", myReader["site_id"], myReader["name"]);
            }
            MySqlConnObj.Close();
            TestWithAdapter();
            //CloseConnection(myConn);
        }
    }
}
