using System;
using System.Linq;

namespace ProgrammingPractice
{
    public static class ArrayOperations
    {
        public static void RotateArrayToPivot()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int pivot = 3;
            array.CopyTo(array, 0);

            //expected output= 4567 123
            var expected = array.Skip(pivot).Take(array.Count() - pivot).Concat(array.Take(pivot));
            Console.WriteLine(expected);

        }
    }
}
