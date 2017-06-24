using System.Linq;
using System;
namespace DAL.MLGDB
{
    public class MLGDBTest
    {
        public void EFTest()
        {
            using (var db = new MLGDBContext())
            {
                var query = from p in db.SiteLists 
                            orderby p.SiteId
                            select p;
                foreach (var item in query)
                {
                    Console.WriteLine("SiteId:{0} and Name:{1}", item.SiteId, item.SiteBranch);
                }
            }
        }
    }
}
