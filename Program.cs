using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter sorter = new Sorter();
            sorter.SortKeyClickedEvent += SortedPersons;  

            while(true)
            {
                try
                {
                    sorter.Sort();
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public static void SortedPersons(int number)
        {
            switch (number)
            {
                case 1: SortByAscending(); break;
                case 2: SortByDescending(); break;
            }
        }

        public static void SortByAscending()
        {
            Console.WriteLine();
            Console.WriteLine("Пользователи отсортированы по фамилии (А-Я)");

            Persons().OrderBy(v => v).ToList().ForEach(v => Console.WriteLine(v));
        }

        public static void SortByDescending()
        {
            Console.WriteLine();
            Console.WriteLine("Пользователи отсортированы по фамилии (Я-А)");

            Persons().OrderByDescending(v => v).ToList().ForEach(v => Console.WriteLine(v));
        }


        public static List<string> Persons()
        {
            List<string> persons = new List<string>();

            persons.Add("Иванов");
            persons.Add("Петров");
            persons.Add("Сидоров");
            persons.Add("Антонов");
            persons.Add("Федотов");

            return persons;
        }
    }

    class Sorter
    {
        public delegate void SortNotify(int number);
        public event SortNotify SortKeyClickedEvent;

        public void Sort()
        {
            Console.WriteLine();
            Console.WriteLine("Для сортировки массива введите 1 (А-Я) или 2 (Я-А)");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            SortKeyClicked(number);
        }

        protected virtual void SortKeyClicked(int number)
        {
            SortKeyClickedEvent?.Invoke(number);
        }

    }


}

