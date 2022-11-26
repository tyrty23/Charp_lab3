using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csharp_lab3;

namespace Csharp_lab3
{

    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class TestCollection<TKey, TValue>
    {
        private List<TKey> list_keys;
        private List<string> list_str;
        private Dictionary<TKey, TValue> dictionary_keys;
        private Dictionary<string, TValue> dictionary_str;
        private GenerateElement<TKey, TValue> generateElement;

        public TestCollection(int count, GenerateElement<TKey, TValue> j)
        {
            list_keys = new List<TKey>();
            list_str = new List<string>();
            dictionary_keys = new Dictionary<TKey, TValue>();
            dictionary_str = new Dictionary<string, TValue>();
            generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var elem = generateElement(i);
                dictionary_keys.Add(elem.Key, elem.Value);
                dictionary_str.Add(elem.Key.ToString(), elem.Value);
                list_keys.Add(elem.Key);
                list_str.Add(elem.Key.ToString());
            }
        }


        public static KeyValuePair<Edition, Magazine> GenerateElement(int j)
        {
            Edition key = new("Издание" + j, j,new DateTime(2000 + j % 30, 1 + j % 12, 1 + j % 30));
            Magazine value = new("Журнал" + j, (Frequency)(j % 3),j, new DateTime(2000 + j % 21, 1 + j % 12, 1 + j % 30));
            return new KeyValuePair<Edition, Magazine>(key, value);
        }


        public void list_key()
        {
            Console.WriteLine("\nВремя поиска в списке по ключу:\n");

            TKey first = list_keys[0];
            TKey middle = list_keys[list_keys.Count / 2];
            TKey last = list_keys[list_keys.Count - 1];
            TKey none = generateElement(list_keys.Count + 1).Key;

            Stopwatch sw = new();
            sw.Start();
            list_keys.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_keys.Contains(middle);
            sw.Stop();
            Console.WriteLine("центральный элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_keys.Contains(last);
            sw.Stop();
            Console.WriteLine("Последний элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_keys.Contains(none);
            sw.Stop();
            Console.WriteLine("элемент не из списка: " + sw.Elapsed);
        }

        public void list_str1()
        {
            Console.WriteLine("\nВремя поиска в списке по значению:\n");

            var first = list_str[0];
            var middle = list_str[list_str.Count / 2];
            var last = list_str[list_str.Count - 1];
            var none = generateElement(list_str.Count + 1).Key.ToString();

            Stopwatch sw = new();
            sw.Start();
            list_str.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_str.Contains(middle);
            sw.Stop();
            Console.WriteLine("центральный элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_str.Contains(last);
            sw.Stop();
            Console.WriteLine("Последний элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            list_str.Contains(none);
            sw.Stop();
            Console.WriteLine("элемент не из списка: " + sw.Elapsed);
        }

        public void dictionary_key_key()
        {
            Console.WriteLine("\nВремя поиска в словаре ключей по ключу:\n");

            TKey first = dictionary_keys.ElementAt(0).Key;
            TKey middle = dictionary_keys.ElementAt(dictionary_keys.Count / 2).Key;
            TKey last = dictionary_keys.ElementAt(dictionary_keys.Count - 1).Key;
            TKey none = generateElement(dictionary_keys.Count + 1).Key;

            Stopwatch sw = new();
            sw.Start();
            dictionary_keys.ContainsKey(first);
            sw.Stop();
            Console.WriteLine("Первый элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            dictionary_keys.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("центральный элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            dictionary_keys.ContainsKey(last);
            sw.Stop();
            Console.WriteLine("Последний элемент: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            dictionary_keys.ContainsKey(none);
            sw.Stop();
            Console.WriteLine("элемент не из списка: " + sw.Elapsed);
        }

        public void dictionary_str_key()
        {
            Console.WriteLine("\nВремя поиска в словаре строк по ключу:\n");

            var first = dictionary_str.ElementAt(0).Key;
            var middle = dictionary_str.ElementAt(dictionary_str.Count / 2).Key;
            var last = dictionary_str.ElementAt(dictionary_str.Count - 1).Key;
            var none = generateElement(dictionary_str.Count + 1).Key.ToString();

            Stopwatch sw = new();
            sw.Start();
            dictionary_str.ContainsKey(first);
            sw.Stop();
            Console.WriteLine("Первый элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_str.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("центральный элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_str.ContainsKey(last);
            sw.Stop();
            Console.WriteLine("Последний элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_str.ContainsKey(none);
            sw.Stop();
            Console.WriteLine("элемент не из списка: " + sw.Elapsed);
        }

        public void dictionary_key_str()
        {
            Console.WriteLine("\nВремя поиска в словаре ключей по значению:\n");

            var first = dictionary_keys.ElementAt(0).Value;
            var middle = dictionary_keys.ElementAt(dictionary_keys.Count / 2).Value;
            var last = dictionary_keys.ElementAt(dictionary_keys.Count - 1).Value;
            var none = generateElement(dictionary_keys.Count + 1).Value;

            Stopwatch sw = new();
            sw.Start();
            dictionary_keys.ContainsValue(first);
            sw.Stop();
            Console.WriteLine("Первый элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_keys.ContainsValue(middle);
            sw.Stop();
            Console.WriteLine("центральный элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_keys.ContainsValue(last);
            sw.Stop();
            Console.WriteLine("Последний элемент: " + sw.Elapsed);

            sw.Reset(); sw.Start();
            dictionary_keys.ContainsValue(none);
            sw.Stop();
            Console.WriteLine("элемент не из списка: " + sw.Elapsed);
        }
    }
}