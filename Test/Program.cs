using System;
using DAL.CADB;
using DAL.MLGDB;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DBConnection db = new DBConnection();
            //db.NewTest();
            //db.TestWithAdapter();
            MLGDBTest mlgEFTest = new MLGDBTest();
            mlgEFTest.EFTest();
            Console.Read();
        }
    }
}
