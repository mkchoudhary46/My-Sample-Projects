using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ProgrammingPractice
{
    public class UserMainCode
    {
        public int GetVisibleCount(int a, int b, int[,] c)
        {
            int count = 0;
            for (int p = 0; p < b; p++)
            {
                for (int i = 0; i < p; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (c[i, j] != p)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayOperations.RotateArrayToPivot();
            Console.ReadKey();

        }

        private static int flag = 1;
        private static int count = 0;

        public void GetKaprikarNo()
        {
            var p = 1;
            var q = 100000;
            bool flag = false;

            while (p <= q)
            {
                var sq = Math.Pow(p, 2); //finding the square of the number  
                string s = sq.ToString(); //converting the square into a String

                if (sq <= 9)
                    s = "0" + s; //Adding a zero in the beginning if the square is of single digit

                int l = s.Length; //finding the length (i.e. no. of digits in the square).
                int mid = l / 2; //finding the middle point

                String left = s.Substring(0, mid); //extracting the left digits from the square
                String right = s.Substring(mid); //extracting the right digits from the square

                int x = int.Parse(left); //converting the left String into Integer
                int y = int.Parse(right); //converting the right String into Integer

                if (x + y == p)
                {
                    flag = true;
                    Console.Write(p + " ");
                }
                p++;
            }
            if (!flag)
            {
                Console.WriteLine("Invalid Range");
            }
        }

        public static string CheckAndConvertobject(dynamic obj)
        {
            // If obj is Type student it asign value to Stuobj else it asign null
            var stuobj = (Employee)obj;
            if (stuobj != null)
                return "This is a Student and his name is " + stuobj.Name;

            return "Not a Student";


        }
        public static IEnumerable<string> Prefixes(IEnumerable<string> words, int length)
        {
            var result = words.Where(x => x.Length >= length).Select(x => x.Substring(0, length)).Distinct();
            return result;
        }

        private static async Task GetDAta()
        {
            var chargeService = new StripeChargeService("sk_test_tdiQWtasXqtjfOxovBh0SuGr");
            var data = await chargeService.GetAsync("ch_199WlvJ6EcgFLMUZjo9G9owG", null);

        }

        public static int GetMajorityElement(params int[] x)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int majority = x.Length / 2;

            //Stores the number of occcurences of each item in the passed array in a dictionary
            foreach (int i in x)
                if (d.ContainsKey(i))
                {
                    d[i]++;
                    //Checks if element just added is the majority element
                    if (d[i] > majority)
                        return i;
                }
                else
                    d.Add(i, 1);
            //No majority element
            throw new Exception("No majority element in array");
        }

        public static int TargetSum(int[] arr, int targetSum)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j)
                    {
                        var sum = arr[i] + arr[j];
                        if (sum == targetSum)
                            return 1;
                    }
                }
            }
            return 0;
        }

        static int MaxRepeating(int[] arr, int n, int k)
        {
            // Iterate though input array, for every element
            // arr[i], increment arr[arr[i]%k] by k
            for (int i = 0; i < n; i++)
            {
                var temp1 = arr[i];
                var temp2 = arr[i] % k;
                var temp3 = arr[(arr[i] % k)];
                var temp4 = arr[(arr[i] % k)] += k;
                // arr[(arr[i] % k)] += k;
            }


            // Find index of the maximum repeating element
            int max = arr[0], result = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }

            /* Uncomment this code to get the original array back
            for (int i = 0; i< n; i++)
              arr[i] = arr[i]%k; */

            // Return index of the maximum element
            return result;
        }

        public static string RemoveDuplicateCharactersFromStrings(string key)
        {
            string table = "";

            // Store the result in this string.
            string result = "";

            // Loop over each character.
            foreach (char value in key)
            {
                // See if character is in the table.
                if (table.IndexOf(value) == -1)
                {
                    // Append to the table and the result.
                    table += value;
                    result += value;
                }
            }
            return result;
        }

        public static void ProcessDesctionary()
        {
            var n = int.Parse(Console.ReadLine());
            var table = new Dictionary<string, int?>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var arr = input.Split(' ');
                table.Add(arr[0], int.Parse(arr[1]));
            }

            var query = Console.ReadLine();
            var queries = new List<string>();
            while (query != null)
            {
                queries.Add(query);
                query = Console.ReadLine();

            }

            foreach (var key in queries)
            {
                if (table.ContainsKey(key))
                    Console.WriteLine(table[key] + "=" + table[key].Value);
                else
                {
                    Console.WriteLine("Not found");
                }

            }
        }

        public static void ReverseArray()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }



        public static void ReverseArrayUptoNth(int n, int[] array)
        {
            for(int i=array.Length-n; i>0; i--)
            {
               for(int j=0; i< array.Length-n; j++)
                {

                }
            }
        }
    }

    #region practice
    public class TextFile1 : IDisposable
    {
        private FileStream _str;
        private bool _id;
        public TextFile1(string filename)
        {
            _str = new FileStream(filename, FileMode.OpenOrCreate);
        }
        public void InsertValue(string buf)
        {
            if (_id)
            {
                throw new ObjectDisposedException("I've been disposed!");
            }
            StreamWriter wr = new StreamWriter(_str);
            wr.WriteLine(System.DateTime.Now);
            wr.WriteLine(buf);
            wr.Close();
        }
        public void Dispose()
        {
            if (_id)
                return;

            _str.Close();
            _str = null;
            _id = true;
            GC.SuppressFinalize(this);
            Console.WriteLine("Object " + GetHashCode() + " disposed.");
        }
    }

    public class MyResource : IDisposable
    {
        private TextReader tr = null;

        public MyResource(string path)
        {
            Console.WriteLine("Aquiring Managed Resources");
            tr = new StreamReader(path);
        }

        public void ShowData()
        {
            //Emulate class usage
            if (tr != null)
            {
                Console.WriteLine(tr.ReadToEnd() + " /some unmanaged data ");
            }
        }

        void ReleaseManagedResources()
        {
            Console.WriteLine("Releasing Managed Resources");
            if (tr != null)
            {
                tr.Dispose();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose called from outside");
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Actual Dispose called with a " + disposing.ToString());
            if (disposing == true)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources
                ReleaseManagedResources();
            }
        }

        ~MyResource()
        {
            Console.WriteLine("Finalizer called");
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }
    }

    public static class ExtensionMethodImplemetation
    {
        public static int WordCountInString(this string str)
        {
            var strArray = str.Split(new char[] { ',', ':', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var count = strArray.Count();
            return count;
        }
    }
    #endregion

    public class DisposableWrapper : IDisposable
    {
        public bool IsDisposing { get; set; }

        public IDisposable UnmanagedResource { get; set; }

        public DisposableWrapper(IDisposable unmanagedResource)
        {
            UnmanagedResource = unmanagedResource;
        }

        public void Dispose()
        {
            Dispose(IsDisposing);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (UnmanagedResource != null)
                {
                    UnmanagedResource.Dispose();
                    UnmanagedResource = null;
                }
                IsDisposing = true;
            }
        }

        ~DisposableWrapper()
        {
            Dispose(true);
        }

    }


    public interface IBird
    {
        Egg Lay();
    }

    // Should implement IBird
    public class Chicken : IBird
    {

        public Chicken()
        {
        }

        public Egg Lay()
        {
            return new Egg(() => new Chicken());
        }
    }

    public class Egg
    {
        private int hatchCount = 0;

        private Func<IBird> birdType;

        public Egg(Func<IBird> createBird)
        {
            birdType = createBird;
        }

        public IBird Hatch()
        {
            IBird bird = null;
            if (hatchCount == 0)
            {
                try
                {
                    bird = birdType.Invoke();
                    hatchCount++;
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                throw new InvalidOperationException("Hatcjing not allowed second time.");
            }
            return bird;
        }
    }

    public class Friend
    {
        public string Email { get; private set; }

        public ICollection<Friend> Friends { get; private set; }

        public Friend(string email)
        {
            this.Email = email;
            this.Friends = new List<Friend>();
        }

        public void AddFriendship(Friend friend)
        {
            this.Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public bool CanBeConnected(Friend friend)
        {
            foreach (var friend1 in Friends)
            {
                return friend1.Friends.Contains(friend);
            }



            return false;
        }
    }

    //class Student
    //{
    //    public int stuNo { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //}
    // Sample Employee Class
    class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

    }

    public class TextInput
    {
        public string curr;

        public virtual void Add(char c)
        {
            curr = string.Concat(curr, c);
        }

        public string GetValue()
        {
            return curr;
        }
    }

    public class NumericInput : TextInput
    {

    }

    class Person
    {
        protected string firstName;
        protected string lastName;
        protected int id;

        public Person() { }
        public Person(string firstName, string lastName, int identification)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = identification;
        }
        public void printPerson()
        {
            Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
        }
    }
    class Student : Person
    {
        private int[] testScores;  
        public Student() { }

        public Student(string firstName, string lastName, int id, int[] scores)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.testScores = scores;
        }
        public char calculate(Student stu)
        {
            var marks = stu.testScores;
            int sum = 0;
            int count = 0;
            foreach (var mark in marks)
            {
                sum += mark;
                count++;
            }
            var avg = sum / count;

            if (avg >= 90 && avg <= 100)
                return 'O';
            if (80 <= avg && avg < 90)
                return 'E';
            if (70 <= avg && avg < 80)
                return 'A';
            if (55 <= avg && avg < 70)
                return 'P';
            if (40 <= avg && avg < 55)
                return 'D';
            return 'T';
        }

    }
}
