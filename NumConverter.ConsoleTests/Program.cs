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
            Console.WriteLine("Write string for conversion to Int32");
            Console.WriteLine("Write 'Exit' to exit programm");

            string input = string.Empty;

            do
            {
                input = Console.ReadLine();

                input = input?.Trim(' ');

                var resultNumber = 0;

                Console.WriteLine(NumHelper.TryParse(input, out resultNumber)
                    ? $"Number from string: {resultNumber}"
                    : $"Can not convert string: {input} to Int32");

            } while (!input.ToLower().Equals("exit"));
        }
    }
}
