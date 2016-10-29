using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            string decimalNumber = "1023";
            string hexadecimalNumber = "3FF";
            string octalNumber = "1777";
            string binaryNumber = "11110001";


            //Console.WriteLine($"{hexadecimalNumber} ---> {hexadecimalNumber.ConvertToBinaryNotation(16)}");
            //Console.WriteLine($"{decimalNumber} ---> {decimalNumber.ConvertToBinaryNotation(10)}");
            //Console.WriteLine($"{octalNumber} ---> {octalNumber.ConvertToBinaryNotation(8)}");


            Console.WriteLine($"Binary to Octal: {binaryNumber} ---> {binaryNumber.ConvertToAnyNotation(2, 8)}");
            Console.WriteLine($"Binary to Decimal: {binaryNumber} ---> {binaryNumber.ConvertToAnyNotation(2, 10)}");
            Console.WriteLine($"Binary to Hexadecimal: {binaryNumber} ---> {binaryNumber.ConvertToAnyNotation(2, 16)}");

            Console.WriteLine();

            Console.WriteLine($"Decimal to Binary: {decimalNumber} ---> {decimalNumber.ConvertToAnyNotation(10, 2)}");
            Console.WriteLine($"Decimal to Octal: {decimalNumber} ---> {decimalNumber.ConvertToAnyNotation(10, 8)}");
            Console.WriteLine($"Decimal to Hexadecimal: {decimalNumber} ---> {decimalNumber.ConvertToAnyNotation(10, 16)}");

            Console.WriteLine();

            Console.WriteLine($"Hexadecimal to Binary: {hexadecimalNumber} ---> {hexadecimalNumber.ConvertToAnyNotation(16, 2)}");
            Console.WriteLine($"Hexadecimal to Octal: {hexadecimalNumber} ---> {hexadecimalNumber.ConvertToAnyNotation(16, 8)}");
            Console.WriteLine($"Hexadecimal to Decimal: {hexadecimalNumber} ---> {hexadecimalNumber.ConvertToAnyNotation(16, 10)}");

            Console.WriteLine();

            Console.WriteLine($"Octal to Binary: {octalNumber} ---> {octalNumber.ConvertToAnyNotation(8, 2)}");
            Console.WriteLine($"Octal to Decimal: {octalNumber} ---> {octalNumber.ConvertToAnyNotation(8, 10)}");
            Console.WriteLine($"Octal to Hexadecimal: {octalNumber} ---> {octalNumber.ConvertToAnyNotation(8, 16)}");

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
