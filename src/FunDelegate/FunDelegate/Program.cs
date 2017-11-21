using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDelegate
{
    class Program
    {
        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            //Init一個Person物件
            Person p = new Person()
            {
                Age = 10,
                Name = "tom"
            };

            #region Func
            //宣告一個Func<Person,string>委託 _thunkCheckAge
            Func<Person, string> _thunkCheckAge;

            //_thunkCheckAge委託指向CheckAge方法
            _thunkCheckAge = new Func<Person, string>(CheckAge);

            //執行_thunkCheckAge委託 (執行CheckAge方法)
            string result = _thunkCheckAge(p);

            //最後將結果顯示出來
            Console.WriteLine(result); 
            #endregion

            #region Action
            //宣告_thunkPerson為Action<Person>委託
            //此Action傳入參數是Person由泛型來決定
            Action<Person> _thunkPerson;
            
            //將CallPersonInfo方法 賦予給_thunkPerson
            _thunkPerson = new Action<Person>(CallPersonInfo);

            //執行_thunkPerson (就是執行CallPersonInfo方法)
            _thunkPerson(p);
            #endregion


            List<Person> pList = new List<Person>()
            {
                new Person() { Age=100,Name="daniel"},
                new Person() { Age=20,Name="Tom" },
                new Person() { Age = 10,Name = "Amy"},
                new Person() { Age=5,Name = "rjo"}
            };

            //如符合此條件的只有daniel和Tom
            foreach (var person in pList.MyWhere(per => per.Age > 10))
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 年紀超過10歲算老人
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static string CheckAge(Person person)
        {
            string result = "年紀剛剛好";
            if (person.Age >= 10)
            {
                result = "老人";
            }
            return result;
        }

        public static void CallPersonInfo(Person person)
        {
            Console.WriteLine($"Age:{person.Age} Name:{person.Name}");
        }
    }
}
