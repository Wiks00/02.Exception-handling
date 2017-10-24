using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumConverter.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 'Exit' to exit programm");

            string input = string.Empty;
            int resultNumber = 0;

            do
            {
                input = Console.ReadLine();

                input = input?.Trim(' ');

                if (NumHelper.TryParse(input,out resultNumber))
                {
                    Console.WriteLine($"Number from string: {resultNumber}");
                }
                else
                {
                    Console.WriteLine($"Can not cinvert string: {input} to Int32");
                }

            } while (!input.ToLower().Equals("exit"));
        }
    }
}
