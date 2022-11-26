using Csharp_lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Csharp_lab3
{
    class Article:IComparable<Article>, IComparer<Article>
    {
        public Person person { get; set; }

        public string Title { get; set; }

        public double Raiting { get; set; }

        public Article(string title1, Person person1, double raiting1)
        {
            person = person1;
            Title = title1;
            Raiting = raiting1;
        }

        public Article()
        {
            person = new Person();
            Title = "Abc";
            Raiting = 7.5;

        }

        public override string ToString()
        {
            return new(Title.ToString() + ' ' + person.ToString1() + ' ' + Raiting.ToString());
        }

        public int CompareTo(Article? ar)
        {
            if (ar is null) throw new ArgumentException("Некорректное значение параметра");
            return Title.CompareTo(ar.Title);
        }

        public int Compare(Article? ar1, Article? ar2)
        {
            if (ar1 is null || ar2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return ar1.person.surname.CompareTo(ar2.person.surname);
        }
    }
}
