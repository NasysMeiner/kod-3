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
            int intermediate = 0;
            int userInput;

            Console.Write("На сколько требуется сдвинуть:");
            userInput = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < userInput; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    intermediate = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = intermediate;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.ReadLine();
        }
    }
}
