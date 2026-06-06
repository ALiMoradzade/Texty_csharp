using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Texty.Utilities
{
    public static class StringNormalizer
    {
        private static char[] persianAplphabet = new char[]
        {
            'آ',
            'ا',
            'ب',
            'ت',
            'ث',
            'ج',
            'ح',
            'خ',
            'د',
            'ذ',
            'ر',
            'ز',
            'س',
            'ش',
            'ص',
            'ض',
            'ط',
            'ظ',
            'ع',
            'غ',
            'ق',
            'ق',
            'ل',
            'م',
            'ن',
            'ه',
            'و',
            'پ',
            'چ',
            'ژ',
            'ک',
            'گ',
            'ی',
        };

        private static string GetRange(char start, char end)
        {
            if (start > end) (start, end) = (end, start);

            int len = end - start + 1;
            StringBuilder result = new StringBuilder(0, len);

            while (start <= end)
            {
                checked
                {
                    result.Append(start);
                    start++;
                }
            }
            return result.ToString();
        }

        public static string ConvertToAsciiDigits(string digits)
        {
            StringBuilder result = new StringBuilder(0, digits.Length);
            foreach (char c in digits)
            {
                if (c >= '۰' && c <= '۹')      // Persian digits 1776-1785
                {
                    result.Append((char)('0' + (c - '۰')));
                }
                else if (c >= '٠' && c <= '٩') // Arabic-Indic digits 1632-1641
                {
                    result.Append((char)('0' + (c - '٠')));
                }
                else                           // ASCII digits 48-57
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string RemoveNonPersianLetters(string text)
        {
            string persianText = string.Concat(text.Where(c => persianAplphabet.Contains(c)));
            return persianText;
        }

        public static string RemoveNonEnglishLetters(string text)
        {
            string englishText = string.Concat
            (
                text.Where
                (
                    c => !char.IsLetter(c) || Regex.IsMatch(c.ToString(), "[a-zA-Z]{1}")
                )
            );
            return englishText;
        }
    }
}
