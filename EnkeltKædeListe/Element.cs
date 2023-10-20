using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnkeltKædeListe
{
    public class Element
    {
        public int Data { get; set; }
        public Element? NextElement { get; set; }

        public Element(int iData, Element? iNextElement)
        {
            Data = iData;
            NextElement = iNextElement;
        }
    }
}
