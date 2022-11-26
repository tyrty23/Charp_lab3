using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Csharp_lab3
{
    class Edition
    {
        protected string jornal;    // название журнала
        protected DateTime datePubl;  // Дата выхода журнала
        protected int editions;       // Тираж

        public Edition(string jornal1, int editions1, DateTime datePubl1)
        {
            jornal = jornal1;
            editions = editions1;
            datePubl = datePubl1;
        }

        public Edition()
        {
            jornal = "BBC";
            datePubl = new DateTime(1970, 01, 01);
            editions = 999;
        }

        public string Jornal
        {
            get { return jornal; }
            set { jornal = value; }
        }

        public int Editions
        {
            get { return editions; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Тираж не может быть отрицательным или нулевым");
                    }
                    else
                    {
                        editions = value;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }

        public DateTime DatePubl
        {
            get { return datePubl; }
            set { datePubl = value; }
        }

        public override string ToString()
        {
            return new(jornal.ToString() + ' ' + datePubl.ToShortDateString() + ' ' + editions.ToString());
        }

        public virtual bool Equals(Edition obj)
        {

            return jornal == obj.jornal && datePubl == obj.datePubl && editions == obj.editions;
        }

        public virtual object DeepCopy()
        {
            Edition obj = new()
            {
                jornal = jornal,
                datePubl = datePubl,
                editions = editions
            };
            return obj;
        }

        public override int GetHashCode()
        {
            return jornal.GetHashCode() ^ datePubl.GetHashCode() ^ editions.GetHashCode();
        }

        //public int CompareTo(Edition? ed)
        //{
        //    if (ed is null) throw new ArgumentException("Некорректное значение параметра");
        //    return jornal.CompareTo(ed.jornal);
        //}

        //public int Compare(Edition? ed1, Edition? ed2)
        //{
        //    if (ed1 is null || ed2 is null)
        //        throw new ArgumentException("Некорректное значение параметра");
        //    return ed1.datePubl.CompareTo(ed2.datePubl);
        //}
    }
}
