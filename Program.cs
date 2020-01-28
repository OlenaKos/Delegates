using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        public delegate int MyDelegate();
        public delegate int MyAnonimousDelegate(int x, int y, int z);
        public delegate int MyArrayDelegate(MyDelegate[] arrDelegate);

        static void Main(string[] args)
        {
            // Task 1
            Func<int, int, int, int> anonimous = delegate(int x, int y, int z) { return ((x + y + z) / 3); };
            MyAnonimousDelegate mydel = delegate(int x, int y, int z) { return ((x + y + z) / 3); };

            Console.WriteLine(anonimous(5, 14, 20));
            Console.WriteLine(mydel(1, 10, 5));

            // Task 2

            Func<double, double, double> Add = (x, y) => { return x + y; };
            Func<double, double, double> Sub = (x, y) => x - y;
            Func<double, double, double> Mul = (x, y) => x * y;
            Predicate<double> isDenominanorZero = y => y == 0;
            Func<double, double, double> Div = (x, y) => isDenominanorZero(y) ? Double.NaN : x / y;

            Console.WriteLine(Add(3, 15));
            Console.WriteLine(Sub(4, 1));
            Console.WriteLine(Mul(3, 4));
            Console.WriteLine(Div(5, 0));
            Console.WriteLine(Div(25, 5));


            // Task 3
            MyDelegate[] delegats = new MyDelegate[3] {method31, method32, method33};

            MyArrayDelegate arrDel = delegate(MyDelegate[] arrDelegats) { return GetAverageValue(arrDelegats); };

            Console.WriteLine("arrDel(delegats)" + arrDel(delegats));
            
            Console.ReadLine();
        }

        private static int GetAverageValue(MyDelegate[] arrDelegats)
        {
            int sum = 0;
            int res = 0;
            for (int i = 0; i < arrDelegats.Length; i++)
            {
                sum += arrDelegats[i](); 
            }

            res = sum / arrDelegats.Length;

            return res;
        }

        private static int method31()
        {
            Random random = new Random();
            return 15;// random.Next(1, 10);
        }
        private static int method32()
        {
            Random random = new Random();
            return 10;// random.Next(1, 15);
        }
        private static int method33()
        {
            Random random = new Random();
            return 5; // random.Next(1, 20);
        }
    }
}
