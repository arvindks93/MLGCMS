using System;
using DAL.CADB;
using DAL.MLGDB;
using ChargeSummary;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestConnectionClasses();
            //TestDeleteCharges();
            Console.Read();
        }
        private static void TestDeleteCharges()
        {
            DeletedCharges deletedcharges = new DeletedCharges();
            deletedcharges.getDataFromCADB();
        }

        private static void TestConnectionClasses()
        {
            DBConnection db = new DBConnection();
            //db.NewTest();
            db.TestWithAdapter();
            //MLGDBTest mlgEFTest = new MLGDBTest();
            //mlgEFTest.EFTest();
        }
    }
}
