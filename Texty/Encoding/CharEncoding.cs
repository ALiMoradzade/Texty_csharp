using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Texty.Encoding
{
    internal class CharEncoding
    {
        private char character;
        private string binary;
        private string octal;
        private string @decimal;
        private string hexadecimal;

        public char Character
        {
            get => character;
        }
        public string Binary
        {
            get => binary;
        }
        public string Octal
        {
            get => octal;
        }
        public string Decimal
        {
            get => @decimal;
        }
        public string Hexadecimal
        {
            get => hexadecimal;

        }

        public void Encode(char character)
        {
            binary = EncodeToBinary(character);
            octal = EncodeToOctal(character);
            @decimal = EncodeToDecimal(character);
            hexadecimal = EncodeToHexadecimal(character);
        }

        public void Decode(int @decimal)
        {
            character = (char)@decimal;
        }

        #region Encoder
        private static string EncodeToBinary(char character)
        {
            int deci = character;
            string decimalToBinary = Convert.ToString(deci, 2);
            string binaryPadLeft = Padding(decimalToBinary, 4, '0', false);
            string fixFormat = Split(binaryPadLeft, 4, " ", true);
            return fixFormat;
        }

        private static string EncodeToOctal(char character)
        {
            int deci = character;
            string decimalToOctal = Convert.ToString(deci, 8);
            string fixFormat = Split(decimalToOctal, 3, " ", true);
            return fixFormat;
        }

        private static string EncodeToDecimal(char character)
        {
            int deci = character;
            string fixFormat = Split(deci.ToString(), 3, ",", true);
            return fixFormat;
        }

        private static string EncodeToHexadecimal(char character)
        {
            int deci = character;
            return $"0x{deci:X}"; // X (uppercase), x (lowercase)
        }
        #endregion

        private static string Padding(string text, int separateCount, char paddingChar, bool fromRight)
        {
            int lengthToBeComplete = Convert.ToInt32
                                   (
                                       Math.Ceiling(text.Length / (double)separateCount) * separateCount
                                   );
            
            string paddedString;
            if (fromRight) paddedString = text.PadRight(lengthToBeComplete, paddingChar);
            else paddedString = text.PadLeft(lengthToBeComplete, paddingChar);
            
            return paddedString;
        }

        private static string Split(string text, int separateCount, string separator, bool fromRight)
        {
            string pattern = ".{" + separateCount + "}";

            string splitedString;
            if (fromRight)
            {
                string reversed = string.Concat(text.Reverse());
                splitedString = Regex.Replace(reversed, pattern, "$0" + separator);
                return string.Concat(splitedString.Reverse());
            }
            else
            {
                splitedString = Regex.Replace(text, pattern, "$0" + separator);
            }
            return splitedString;
        }
    }
}
