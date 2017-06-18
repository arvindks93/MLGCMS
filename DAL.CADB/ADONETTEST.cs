using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace DAL.CADB
{
    class ADONETTEST
    {
        public void testDataSets()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Student");
            DataColumn dc = new DataColumn();
            dt.Columns.Add("StudentId", Type.GetType("System.string"));

            ds.Tables.Add();
        }
    }
}
