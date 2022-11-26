using Csharp_lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp_lab3
{
    internal class EditionCampare: IComparer<Edition>
    {
        public int Compare(Edition? ed1, Edition? ed2)
        {
            if (ed1 is null || ed2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return ed1.Editions-ed2.Editions;
        }
    }
}
