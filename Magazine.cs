using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;
using Csharp_lab3;

namespace Csharp_lab3
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }

    class Magazine : Edition
    {
        private Frequency period;
        private List<Person> redactor;
        private List<Article> jornals;

        public Magazine(string jornal1, Frequency period1, int editions1, DateTime datePubl1) : base(jornal1, editions1, datePubl1)
        {
            period = period1;
            redactor = new(0);
            jornals = new(0);
        }

        public Magazine() : base()
        {
            period = Frequency.Weekly;
            //Person fio;
            ////redactor = new List<Person>();
            //redactor.Add(fio);
            //jornals = new ArrayList();  
            redactor = new List<Person>();
            jornals = new List<Article>();

        }

        public string CountOfRedactor()
        {
            return redactor.Count.ToString();
        }

        public string CountOfJornals()
        {
            return jornals.Count.ToString();
        }

        public Frequency Period
        {
            get { return period; }
            set { period = value; }
        }

        public List<Article> Jornals
        {
            get { return jornals; }
            set { jornals = value; }
        }

        public List<Person> Redactor
        {
            get { return redactor; }
            set { redactor = value; }
        }

        public double AverageRaiting
        {
            get
            {
                if (jornals.Count == 0)
                {
                    return 0.0;
                }
                if (jornals == null)
                {
                    return 0.0;
                }

                double sum = 0;
                for (int i = 0; i < jornals.Count; i++)
                    sum += jornals[i].Raiting;
                return sum / jornals.Count;
            }

        }

        public bool this[Frequency period1]
        {
            get
            {
                return period == period1;
            }
        }

        public override string ToString()
        {
            string output = "\n";
            output += jornal.ToString() + ' ' + period.ToString() + ' ' + datePubl.ToShortDateString()
                + ' ' + editions.ToString() + "\n Статьи:\n";
            foreach (Article element in jornals)
            {
                output += element.Title.ToString() + ' ' + element.person.ToString1() + ' ' + element.Raiting.ToString()+"\n";
            }
            output += " Редакторы:\n";
            foreach (Person element in redactor)
            {
                output += element.ToString()+"\n";
            }
            return output;
        }

        public Edition Edition
        {
            get
            {
                return new Edition(jornal, editions, datePubl);
            }
        }

        public void AddArticle( List<Article> jorn)
        {
            //if (jornals.Count == 0)
            //{
            //    jornals = new List<Article>();
            //}
            foreach (Article element in jorn)
            {
                jornals.Add(element);
            }
        }

        public void AddEditor(List<Person> red)
        {
            //if (redactor == null)
            //{
            //    Person test = new();
            //    redactor.Add(test);
            //}
            foreach (Person element in red)
                redactor.Add(element);
            
        }

        public virtual string ToShortString()
        {
            return "Журнал: " + jornal + "\nПереодичность: " + period
                + "\nДата выхода: " + datePubl.ToShortDateString() +
                "\nТираж: " + editions.ToString() + "\nСредний рейтинг: " + AverageRaiting.ToString();
        }

        public override object DeepCopy()
        {

            Magazine obj = new()
            {
                jornal = jornal,
                datePubl = datePubl,
                editions = editions,
                period = period
            };
            Person[] red = new Person[redactor.Count()];
            Article[] jorn = new Article[jornals.Count()];
            redactor.CopyTo(0, red, 0, redactor.Count());
            jornals.CopyTo(0, jorn, 0, jornals.Count());
            //obj.AddEditor(red);
            //obj.AddArticle(jorn);

            return obj;
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(jornals, redactor);
        }

        public IEnumerable Edit_red()
        {

            foreach (Person element in redactor)
            {
                foreach (Article element2 in jornals)
                {
                    if (element.Equals(element2.person))
                        yield return element2;
                }
            }
        }

        public IEnumerable Edit_no_art()
        {
            int count = 0;
            for (int i = 0; i < redactor.Count; i++)
            {
                bool isCorrect = false;
                for (int j = 0; j < jornals.Count; j++)
                {

                    if (jornals[j].person.Equals(redactor[i]))
                    {
                        isCorrect = true;
                        break;
                    }
                }
                if (!isCorrect)
                {
                    count++;
                    yield return redactor[i];

                }
            }
            if (count == 0)
            {
                Console.WriteLine("У всех редакторов есть публикации");
            }
        }

        public void SortByName()
        {
            jornals.Sort();
        }

        public void SortBySurname()
        {
            jornals.Sort(new Article());
        }

        public void SortByRaiting()
        {
            jornals.Sort(new ArticleCampare());
        }
    }
}
