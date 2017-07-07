using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTestsAndPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello");
            //MergeSorts ms = new MergeSorts();
            //ms.TestMergeSort();
            NewMerge nms = new NewMerge();
            nms.MergeMain();
        }
    }
}
