using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTestsAndPOC
{
    public class SortingAlgorithms
    {
    }
    
    public class InsertionSorts
    {
    }
    public class SelectionSorts
    {

    }
    public class BubbleSorts
    {
        // Bubble sort, and variants such as the cocktail sort, are simple but highly inefficient sorts.
        //They are thus frequently seen in introductory texts, and are of some theoretical interest due to ease of analysis, 
        //but they are rarely used in practice, and primarily of recreational interest.

    }
    public class ShellSorts
    {
        // Bubble sort, and variants such as the cocktail sort, are simple but highly inefficient sorts.
        //They are thus frequently seen in introductory texts, and are of some theoretical interest due to ease of analysis, 
        //but they are rarely used in practice, and primarily of recreational interest.
    }
    public class MergeSorts
    {
        /*Efficient sorts
         - It is the only sorting algorithm that is stable. It is very predictable, takes time nlog(n), does not require 
         randon access to data, least time for sorted elemnst and max fro random elements.
         Most used sorting algo.  It will require more space on stack and memory ran out of call stack error is possible here.
         */
         public void Merge_Recursion(int[] members, int left, int right)
        {
            int mid;
            if (left<right)
            {
                mid = (right + left) / 2;
                Merge_Recursion(members, left, mid);
                Merge_Recursion(members, mid + 1, right);
                Merge(members, left, mid, right);
            }
        }
        public void Merge(int[] members, int left, int mid, int right)
        {
            int p = left; int q = mid + 1;
            int[] tempArray = new int[right-left+1];
            int k = 0;
            for (int i=left; i<=right; i++) //Check if the fist part comes to an end.
            {
                if (p>mid)
                {
                    tempArray[k++] = members[q++];
                }
                else if (q>right) // Check if second array has come to end
                {
                    tempArray[k++] = members[p++];
                }
                else if (members[p]<members[q])
                {
                    tempArray[k++] = members[p++];
                }
                else
                {
                    tempArray[k++] = members[q++];
                }
            }
            //Now the temp has sorted array and assign it to the original list
             for (int j=0; j<k; j++)
            {
                members[j++] = tempArray[j++];
            }
             for (int i=0; i<members.Length-1; i++)
            {
                Console.WriteLine(members[i]);
            }
        }
        public void TestMergeSort()
        {
            int[] a = { 6, 3, 8, 4, 7 };
            Merge_Recursion(a, 0, a.Length);
        }
    }
    public class NewMerge
    {
        public void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= eol)
                temp[pos++] = numbers[left++];

            while (mid <= right)
                temp[pos++] = numbers[mid++];

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        public void SortMerge(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(numbers, left, mid);
                SortMerge(numbers, (mid + 1), right);

                MainMerge(numbers, left, (mid + 1), right);
            }
        }
        public void MergeMain()
        {

            Console.Write("\nProgram for sorting a numeric array using Merge Sorting");
            Console.Write("\n\nEnter number of elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[max];
            for (int i = 0; i < max; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Input int array : ");
            Console.Write("\n");
            for (int k = 0; k < max; k++)
            {
                Console.Write(numbers[k] + " ");
                Console.Write("\n");
            }
            Console.WriteLine("MergeSort By Recursive Method");
            SortMerge(numbers, 0, max - 1);
            for (int i = 0; i < max; i++)
                Console.WriteLine(numbers[i]);
            Console.ReadLine();
        }
    }
    public class QuickSorts
    {
        //Efficient sorts
        //The Quicksort is generally fastest.It is by far the most commonly used sorting algorithm. Yet there are signs that Shell sort is making a comeback in embedded systems, because it concise to code and is still quite fast.
    }
    public class HeapSorts
    {
        //Efficient sorts
    }
    public class BucketSorts
    {
        //Disttribution sorts
        //Distribution sort refers to any sorting algorithm where data are distributed from their input to multiple intermediate structures which are then gathered and placed on the output
    }
    public class RadisxSorts
    {
        //Disttribution sorts
        //Distribution sort refers to any sorting algorithm where data are distributed from their input to multiple intermediate structures which are then gathered and placed on the output
    }

    public class GeneralFunctions
    {
        public int[] Swap(int [] data, int m, int n)
        {
            int temp;
            temp = data[m];
            data[m] = data[n];
            data[n] = temp;
            return data;
        }
    }
}
