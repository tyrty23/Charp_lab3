namespace Csharp_lab3
{
    internal class ArticleCampare : IComparer<Article>
    {
        public int Compare(Article? ed1, Article? ed2)
        {
            if (ed1 is null || ed2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return (int)((int)ed1.Raiting - ed2.Raiting);
        }
    }
}