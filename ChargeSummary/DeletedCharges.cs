using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.CADB;

namespace ChargeSummary
{
    public class DeletedCharges
    {
        public void getDataFromCADB()
        {
            string strSQL;
            DataTable dt = new DataTable();

            strSQL = "select a.msg_id as msg_id, a.file_id as file_id, a.case_id as case_id, c.file_num as file_num, b.case_num as case_num,c.loan_num as loan_num,b.cur_case_stat_id as cur_case_stat_id, c.state as state"
                + ",a.msg_dt as msg_dt, a.create_by as create_by, a.create_dt as create_dt, a.notes as notes, e.flex_2 as sitebranch,"
                + "trim(substring(a.notes,(locate('Full Amount:', a.notes) + length('Full Amount:')),"
                + "(locate('Waived/Absorbed', a.notes) - locate('Full Amount:', a.notes) - length('Full Amount:')))) as Amount ,"
                + "trim(substring(a.notes,(locate('Charge:', a.notes) + length('Charge:')),"
                + "(locate('Full Amount:', a.notes) - locate('Charge:', a.notes) - length('Charge:')))) as Charge_Type"
                + " from msgsent a"
                + "inner join case_lst b on a.case_id = b.case_id"
                + "inner join file_lst c on c.file_id = a.file_id"
                + "inner join case_flex e on a.case_id = e.case_id"
                + "where (a.subj ='Case Charge Deleted') and (a.create_dt > '2017-06-01');";
            DBConnection dbconn = new DBConnection();
            dt = dbconn.GetDisconnectedData(strSQL);
            for (int i=0; i<10; i++)
            {
                DataRow dr = dt.Rows[i];
                Console.WriteLine("File:{0}",dr["file_num"]);
                Console.WriteLine("site:{0}", dr["sitebranch"]);
                Console.WriteLine("Amount:(0)", dr["Amount"]);
                Console.WriteLine("Charge Type:(0)", dr["Charge_Type"]);
            }
            Console.Read();            
        }
    }
}
