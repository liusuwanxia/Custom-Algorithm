using System;
using System.Collections.Generic;
using Custom_Algorithm;

namespace TestProgram
{    
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 5, 1, 2, 7 };
            Console.WriteLine(StackProblem.GetSubArrayCountByMaxAndMin(arr, 2));
        }
    }
}
