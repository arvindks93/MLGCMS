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
            string strSQL ;
            //strSQL = "Select a.msg_id, a.case_id, c.cur_case_stat_id as case_status, b.flex_2 as site, a.notes, a.create_by, a.create_dt from msgsent a "
            //    + "inner join case_flex b on a.case_id=b.case_id "
            //    + "inner join case_lst c on a.case_id=c.case_id "
            //    + "where (a.subj='Case Charge Deleted') AND (a.create_dt>'2017-06-01') "
            //    + "limit 10;"; //"SELECT * FROM site_lst";

            strSQL = "select a.msg_id, b.case_num, c.file_num, a.notes "
            + " , trim(substring(a.notes, (locate('Amount:', a.notes) + length('Amount:')), (locate('Expect', a.notes) - locate('Amount:', a.notes) - length('Amount:')))) as Amount "
            + " , trim(substring(a.notes, (locate('Charge:', a.notes) + length('Charge:')), (locate('Amount:', a.notes) - locate('Charge:', a.notes) - length('Charge:')))) as Charge_Type "
            + " from msgsent a "
            + " inner join case_lst b on a.case_id = b.case_id "
            + " inner join file_lst c on c.file_id = a.file_id "
            + " where (a.subj = 'Case Charge Deleted') and (a.create_dt > '2017-06-01');"
            ;

            DataTable dt = GetDisconnectedData(strSQL);
            Console.WriteLine("Disconnected Data Sets");
            foreach(DataRow dr in dt.Rows)
            {
                //find charge type

                //Console.WriteLine("Site ID:{0} and Site Name is: {1}", dr["site_id"], dr["name"]);
                Console.WriteLine("Charge type:{0} and length:{1}", dr["charge_type"].ToString().Trim(), dr["charge_type"].ToString().Length);   
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
