using System.Collections.Generic;

namespace StrategyPatternPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ISortingStrategy sortingStrategy = null;

            List<int> studentNumbers = new List<int>() { 123, 32, 12, 1 };

            sortingStrategy = GetSortingOptions(ObjectsToSort.StudentNumber);

            sortingStrategy.Sort(studentNumbers);
        }


        private static ISortingStrategy GetSortingOptions(ObjectsToSort objectToSort)
        {
            ISortingStrategy sortingStrategy = null;

            switch (objectToSort)
            {
                case ObjectsToSort.StudentNumber:
                    sortingStrategy = new QuickSort();
                    break;

                case ObjectsToSort.RailwayPassenger:
                    sortingStrategy = new MergeSort();
                    break;

                case ObjectsToSort.CountyResidents:
                    sortingStrategy = new HeapSort();
                    break;
                default:
                    break;

            }
            return null;
        }
    }

    public enum ObjectsToSort
    {
        StudentNumber,
        RailwayPassenger,
        CountyResidents
    }

    public interface ISortingStrategy
    {

        void Sort<T>(List<T> dataToBeSorted);
    }

    public class QuickSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            //Logic for quick sort.
        }
    }
    public class MergeSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            //
        }
    }

    public class HeapSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            //
        }
    }

}
