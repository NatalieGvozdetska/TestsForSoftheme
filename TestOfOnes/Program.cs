using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOfOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            var path2file = Directory.GetCurrentDirectory();
            string str = "";
            try
            {
                str = System.IO.File.ReadAllText(path2file + "\\INPUT.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File INPUT.txt does not exist. Please, create it in project folder /bin/debug");
                Console.ReadKey();
                return;
            }
            try
            {
                System.IO.File.WriteAllText(path2file + "\\OUTPUT.txt", Convert.ToString(LongOfOnes(str)));
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File OUTPUT.txt does not exist. Please, create it in project folder /bin/debug");
                Console.ReadKey();
                return;
            }
        }

        public static int LongOfOnes(string input)
        {
            List<int> countones = new List<int>();
            int x = 0;
            countones.Add(x);
            for (int i = 0; i < input.Length; ++i)
            {
                if (i != 0 && input[i] == '1' && input[i - 1] == '0') //начало новой последовательности единиц
                {
                    x = 0;
                    countones.Add(x);
                }
                if (input[i] == '1') //считаем единицы в последовательности
                {
                    x++;
                    countones[countones.Count - 1] = x;
                }
                else
                {
                    continue;
                }
            }
            return countones.Max();
        }
    }
}
