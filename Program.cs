using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = { "1", "2", "3", "3", "4", "5", };
            string[] line2 = { "1", "2", "3", "6", "7", "8", };

            List<string> lines = new List<string>();

            lines.AddRange(line1);
            lines.AddRange(line2);

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 1; j < lines.Count; j++)
                {
                    if (lines[i] == lines[j] && i != j)
                    {
                        lines.RemoveAt(j);
                    }
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.ReadLine();
        }
    }
}
