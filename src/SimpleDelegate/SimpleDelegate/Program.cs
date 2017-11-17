using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    public class Program
    {
        public delegate void voidDelegate();
        public delegate int calcInt(int arg1,int arg2);
        static void Main(string[] args)
        {
            //Assert delegate is Class
            Console.WriteLine($"delegate is class? {typeof(voidDelegate).IsClass}");

            //delegate with normal syntax
            calcInt calcint = new calcInt(add);
            var result1 = calcint(5,5);
            Console.WriteLine($"result1:{result1}");

            //delegate with suger syntax 
            calcInt calcint1 = (a,b) => { return a + b; };
            var result2 = calcint1(5, 5);
            Console.WriteLine($"result2:{result2}");


            List<int> i_List = new List<int>()
            {
                1,3,5,7,9
            };
            Calculator<int> calculator = new Calculator<int>(i_List);
            int i_add = calculator.Excute((list) => list.Sum());
            int i_multi = calculator.Excute((list) =>
            {
                int totle = 1;
                foreach (var i in list)
                {
                    totle *= i;
                }
                return totle;
            });
            Console.WriteLine($"add:{i_add}  multi:{i_multi}");


            Console.ReadKey();
        }

        static int add(int a, int b)
        {
            return a + b;
        }
    }
    public class Calculator<T>
        where T : struct
    {
        public delegate T Calc(IList<T> list);

        IList<T> _container;
        public Calculator(IList<T> container)
        {
            _container = container;
        }
        public T Excute(Calc C)
        {
            return C(_container);
        }
    }
}
