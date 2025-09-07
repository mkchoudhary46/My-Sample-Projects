using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingPractice
{
    public static class StringOperations
    {

        public static void PrintDuplicateCharactersFromString(string str)
        {
            var table = new Dictionary<char, int>();

            foreach (var item in str)
            {
                if (table.ContainsKey(item))
                {
                    table[item] += 1;
                }
                else
                    table[item] = 1;
            }

            foreach (var item in table)
            {
                Console.WriteLine(table[item.Key]);
            }
        }

        public static bool CheckIfStringsAreAnagram(string str1, string str2)
        {
            var arr1 = str1.ToLower().ToCharArray();
            Array.Sort(arr1);
            var arr2 = str2.ToCharArray();
            Array.Sort(arr2);

            var strOne = arr1.ToString();
            var strTwo = arr2.ToString();
            if (strOne.Equals(strTwo))
            {
                return true;
            }
            return false;
        }

        public static bool StringContainsDigitOnly(string str)
        {
            if (str.All(Char.IsDigit))
            {
                return true;
            }
            return false;
        }

        public static string ReverseWordsOfString(string str)
        {
            string output = string.Empty;
            var words = str.Split(' ');
            foreach (var item in words)
            {
                item.Reverse();
                output += item + " ";
            }
            Console.WriteLine(output);
            return output;

        }
    }
}
