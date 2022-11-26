using Csharp_lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp_lab3
{
    delegate TKey KeySelector<TKey>(Magazine mg);

    internal class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> magazin;

        private KeySelector<TKey> key1;

        public MagazineCollection(KeySelector<TKey> val)
        {
            key1 = val;
            magazin = new Dictionary<TKey, Magazine>();
        }

        public static string Define_Key(Magazine val)
        {
            return val.Editions.ToString();
        }

        public void AddDefaults()
        {
            Magazine magazine = new();
            magazin.Add(key1(magazine), magazine);
        }

        public void AddMagazines(params Magazine[] mag)
        {
            //if (magazin.Count == 0)
            //{
            //    Magazine mag1 = new Magazine();
            //    magazin = Dictionary<key1(mag1),mag1>;
            //}
            foreach (Magazine element in mag)
            {
                magazin.Add(key1(element), element);
            }
        }

        public override string ToString()
        {
            string output = " ";
            foreach (KeyValuePair<TKey, Magazine> element in magazin)
            {
                output +=
                "\nЗначение ключа: "+ element.Key+ "\n"
                + element.Value.ToString()
                +"\n";
            }
            return output;
        }

        public virtual string ToShortString()
        {
            string output = " ";
            foreach (KeyValuePair<TKey, Magazine> element in magazin)
            {
                output += "\nЖурнал: " + element.Value.Jornal
                + "\nПереодичность: " + element.Value.Period
                + "\nДата выхода: " + element.Value.DatePubl.ToShortDateString()
                + "\nТираж: " + element.Value.Editions.ToString()
                + "\nСредний рейтинг: " + element.Value.AverageRaiting.ToString()
                + "\nКоличество редакторов: " + element.Value.CountOfRedactor()
                + "\nКоличество статей: " + element.Value.CountOfJornals();

            }
            return output;
        }

        public double MaxRating
        {
            get
            {
                if (magazin.Count > 0)
                {
                    return magazin.Max(mag => mag.Value.AverageRaiting);
                }
                return 0;
                //if (magazin.Count > 0) { return 0.0; }
                //double[] rat = new double[10];
                //foreach (KeyValuePair<TKey, Magazine> element in magazin)
                //{
                //    rat.Append(element.Value.AverageRaiting);
                //}
                //return Enumerable.Max(rat);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            //IEnumerable<string> query = magazin.Where(m => m.Period ==value);
            //foreach (KeyValuePair<TKey, Magazine> element in magazin);
            return magazin.Where(mag => mag.Value.Period == value);
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupFr
        {
            get
            {
                return magazin.GroupBy(mag => mag.Value.Period);
            }
        }
    }
}
 