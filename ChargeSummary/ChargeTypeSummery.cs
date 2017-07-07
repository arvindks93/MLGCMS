using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeSummary
{
   public class ChargeTypeSummery
    {
         
        public int ID { get; set; }
        public int ChargeTypeId { get; set; }
        public int CaseSiteId { get; set; }
        public int CostFeeIndicator { get; set; }
        public int DepartmentId { get; set; }
        public int CaseId { get; set; }
        public double ChargeAmount { get; set; }
        public DateTime Transactiondate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CaseSiteList
    {
        public int ID { get; set; }
        public string SiteName { get; set; }
    }
    public class DepartmentList
    {
        //create a Department Other with ID 999999
        public int ID { get; set; }
        public string DepartmentName { get; set; }
    }
}
