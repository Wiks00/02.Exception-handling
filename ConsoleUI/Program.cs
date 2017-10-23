using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Exceptions;
using NumConverter;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 'Exit' to exit programm");

            string input = string.Empty;
            List<char> chars = new List<char>();
       
            do
            {
                input = Console.ReadLine();

                input = input?.Trim(' ');

                if (string.IsNullOrEmpty(input))
                {
                   throw new InputException("Input string can't be empty");
                }

                chars.Add(input[0]);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                Console.WriteLine($"First cahrs : {string.Join(", ", chars)}");
                Console.SetCursorPosition(0, Console.CursorTop - 2); 

            } while (!input.ToLower().Equals("exit"));
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
