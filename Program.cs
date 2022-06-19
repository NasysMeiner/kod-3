using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int a = 0;

            for (int i = array.Length - 1; i > 0; i--)
            {
                a = array[i];
                array[i] = array[i - 1];
                array[i - 1] = a;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.ReadLine();
        }
    }
}
