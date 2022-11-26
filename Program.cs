using Charp_lab3;
using Csharp_lab3;
using System;
using System.Diagnostics;

namespace Csharp_lab3
{
    enum Frequency { Weekly, Monthly, Yearly }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("      Задание №1      \n");
            List<Person> edit = new(6)
            {
                new Person("Игорь", "Гайдук", new DateTime(2007, 7, 1)),
                new Person("Тамара", "Морозова", new DateTime(2004, 2, 4)),
                new Person("Иван", "Иванов", new DateTime(2015, 01, 01)),
                new Person("Андрей", "Сидоров", new DateTime(2001, 2, 2)),
                new Person("Антон", "Городецкий", new DateTime(2002, 5, 8)),
                new Person("Виталий", "Рогоза", new DateTime(2002, 12, 9))
            };

            List<Article> art = new(6)
            {
                new Article("XXX", new Person("Лютик", "Ван Лютенхов", new DateTime(2002, 7, 9)), 5),
                new Article("YYY", new Person("Геральт", "Ривийский", new DateTime(2000, 6, 4)), 6),
                new Article("AAA", new Person("Иван", "Иванов", new DateTime(2015, 01, 01)), 5),
                new Article("BBB", new Person("Андрей", "Сидоров", new DateTime(2001, 2, 2)), 8),
                new Article("CCC", new Person("Василий", "Мельников", new DateTime(2002, 3, 3)), 6),
                new Article("DDD", new Person("Владимир", "Кузнецов", new DateTime(2003, 4, 4)), 9)
            };

            Magazine mag = new("BBC", Frequency.Weekly, 10000,new DateTime(2021, 10, 14));

            mag.AddEditor(edit);
            mag.AddArticle(art);

            Console.WriteLine("Data of test_Magazine: ");
            Console.WriteLine(mag.ToString());

            mag.SortByName();
            Console.WriteLine("\n\nСортировка по названию статьи: ");
            Console.WriteLine(mag.ToString());

            mag.SortBySurname();
            Console.WriteLine("\n\nСортировка по фамилии автора: ");
            Console.WriteLine(mag.ToString());

            mag.SortByRaiting();
            Console.WriteLine("\n\nСортировка по рейтингу: ");
            Console.WriteLine(mag.ToString());

            Console.WriteLine("\n\n      Задание №2      \n");

            MagazineCollection<string> mags = new(MagazineCollection<string>.Define_Key);

            List<Person> edit2 = new(2)
            {
                new Person("Игорь", "Гайдук", new DateTime(2007, 7, 1)),
                new Person("Тамара", "Морозова", new DateTime(2004, 2, 4))
            };

            List<Person> edit3 = new(2)
            {
                new Person("Иван", "Иванов", new DateTime(2015, 01, 01)),
                new Person("Андрей", "Сидоров", new DateTime(2001, 2, 2))
            };

            List<Person> edit4 = new(2)
            {
                new Person("Антон", "Городецкий", new DateTime(2002, 5, 8)),
                new Person("Виталий", "Рогоза", new DateTime(2002, 12, 9))
            };

            List<Article> art2 = new(2)
            {
                new Article("XXX", new Person("Лютик", "Ван Лютенхов", new DateTime(2002, 7, 9)), 5),
                new Article("YYY", new Person("Геральт", "Ривийский", new DateTime(2000, 6, 4)), 6)
            };

            List<Article> art3 = new(2)
            {
                new Article("AAA", new Person("Иван", "Иванов", new DateTime(2015, 01, 01)), 5),
                new Article("BBB", new Person("Андрей", "Сидоров", new DateTime(2001, 2, 2)), 8)
            };

            List<Article> art4 = new(2)
            {
                new Article("CCC", new Person("Василий", "Мельников", new DateTime(2002, 3, 3)), 6),
                new Article("DDD", new Person("Владимир", "Кузнецов", new DateTime(2003, 4, 4)), 9)
            };

            Magazine mag2 = new("Квант", Frequency.Monthly, 1000, new DateTime(2027, 10, 11));
            mag2.AddEditor(edit2);
            mag2.AddArticle(art2);

            Magazine mag3 = new("Geo", Frequency.Yearly,2500, new DateTime(2004, 2, 18));
            mag3.AddEditor(edit3);
            mag3.AddArticle(art3);

            Magazine mag4 = new("Форбс", Frequency.Weekly,7870, new DateTime(2022, 01, 01));
            mag4.AddEditor(edit4);
            mag4.AddArticle(art4);

            //mags.AddDefaults();
            mags.AddMagazines(mag2);
            mags.AddMagazines(mag3);
            mags.AddMagazines(mag4);
            Console.WriteLine(mags);

            Console.WriteLine("\n\n      Задание №3     \n");
            Console.WriteLine("Максимальный средний рейтинг: ");
            Console.WriteLine(mags.MaxRating);

            Console.WriteLine("журналы с заданной переодичностью: ");
            var test = mags.FrequencyGroup(Frequency.Weekly);
            foreach (var element in test)
            {
                Console.WriteLine(element.Value);
            }

            Console.WriteLine("журналы,отсортированные по переодичности: ");
            var test2 = mags.GroupFr;
            foreach (var element in test2)
            {
                Console.WriteLine();
                foreach (var item in element)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\n\n      Задание №4     \n");
            Console.WriteLine("Введите колличество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());

            TestCollection<Edition, Magazine> search = new(n, TestCollection<Edition, Magazine>.GenerateElement);
            search.list_key();
            search.list_str1();
            search.dictionary_key_key();
            search.dictionary_str_key();
            search.dictionary_key_str();

        }
    }
}