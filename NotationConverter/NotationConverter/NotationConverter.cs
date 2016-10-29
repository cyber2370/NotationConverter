using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationConverter
{
    public static class NotationConverter
    {
        private static readonly string[] _binaryValues;

        static NotationConverter()
        {
            _binaryValues = new string[]
            {
                "00000", "00001", "00010", "00011", "00100", "00101", "00110", "00111",
                "01000", "01001", "01010", "01011", "01100", "01101", "01110", "01111",
                "10000", "10001", "10010", "10011", "10100", "10101", "10110", "10111",
                "11000", "11001", "11010", "11011", "11100", "11101", "11110", "11111"
            };
        }

        public static string ConvertToBinaryNotation(this string number, int notation)
        {
            if (notation == 2)
            {
                return number;
            }

            if (notation == 10)
            {
                return ConvertFromDecimalToBinary(Convert.ToInt32(number));
            }

            int numberOfDigitsPerElement = FindNumberOfDigitsPerElement(notation);
            string[] binaryValues = _binaryValues
                .Take(Convert.ToInt32(Math.Pow(2, numberOfDigitsPerElement)))
                .Select(x => x.Remove(0, x.Length - numberOfDigitsPerElement))
                .ToArray();

            string result = "";

            for(int i = 0; i < number.Length; i++)
            {
                char currentValue = number[i];

                int binaryArrayIndex;
                bool isConvertSuccess = int.TryParse(currentValue.ToString(), out binaryArrayIndex);

                if (!isConvertSuccess)
                {
                    binaryArrayIndex = 10 + Convert.ToInt32(currentValue - 65);
                }

                result += binaryValues[binaryArrayIndex];
            }

            return result;
        }

        public static string ConvertToAnyNotation(this string number, int fromNotation, int toNotation)
        {
            string result = "";

            string binaryNumber = ConvertToBinaryNotation(number, fromNotation);

            if (toNotation == 10)
            {
                return ConvertFromBinaryToDecimal(binaryNumber).ToString();
            }

            int numberOfDigitsPerElement = FindNumberOfDigitsPerElement(toNotation);
            string[] binaryValues = _binaryValues
                .Take(Convert.ToInt32(Math.Pow(2, numberOfDigitsPerElement)))
                .Select(x => x.Remove(0, x.Length - numberOfDigitsPerElement))
                .ToArray();

            binaryNumber = ComplementBinaryToFullNotation(binaryNumber, numberOfDigitsPerElement);

            while(binaryNumber.Length != 0)
            {
                string entry = string.Join("", binaryNumber.Take(numberOfDigitsPerElement));
                binaryNumber = binaryNumber.Remove(0, numberOfDigitsPerElement);

                int index = Array.IndexOf(binaryValues, entry);
                result += index < 10 ? index.ToString() : Convert.ToChar(65 + (index - 10) ).ToString();
            }

            return result;
        }

        private static int ConvertFromBinaryToDecimal(string binary) 
        {
            int result = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '0')
                    continue;

                result += Convert.ToInt32(Math.Pow(2, binary.Length - i - 1));
            }

            return result;
        }

        private static string ConvertFromDecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "000";
            }

            string result = "";

            while (decimalNumber != 0)
            {
                if(decimalNumber % 2 == 1)
                {
                    result += "1";
                    decimalNumber--;
                }
                else
                {
                    result += "0";
                }

                decimalNumber /= 2;
            }

            return string.Join("", result.Reverse());
        }

        private static string ComplementBinaryToFullNotation(
            string binary, 
            int numberOfDigitsPerElement)
        {
            int modulo = binary.Length % numberOfDigitsPerElement;

            if (modulo == 0)
                return binary;

            modulo = numberOfDigitsPerElement - modulo;

            for(int i = 0; i < modulo; i++)
            {
                binary = "0" + binary;
            }

            return binary;
        }

        private static int FindNumberOfDigitsPerElement(int notation)
        {
            int value, powerCounter;

            for(value = 2, powerCounter = 1; value < notation; value *= 2, powerCounter++)
            { }

            return powerCounter;
        }
    }
}
