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
                var query = from p in db.Blogs 
                            orderby p.BlogId
                            select p;
                foreach (var item in query)
                {
                    Console.WriteLine("BlogId:{0} and Name:{1}", item.BlogId, item.Name);
                }
            }
        }
    }
}
