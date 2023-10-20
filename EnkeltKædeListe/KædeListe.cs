using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnkeltKædeListe
{
    public class KædeListe
    {
        public Element First { get; set; } = null;

        public KædeListe()
        {
            
        }

        public void Add(int iData)
        {
            Element newElement = new Element(iData, First);
            First = newElement;
        }

        public void Remove(int index)
        {
            if (First != null) 
            {
                bool keepRunning = true;
                int count = 0;
                Element CurrentCheck = First;
                Element PrevCheck = null;
                do
                {
                    count++;
                    if (index == count)
                    {
                        keepRunning = false;
                        if (PrevCheck == null)
                        {
                            First = CurrentCheck.NextElement;
                        }
                        else if (CurrentCheck.NextElement == null)
                        {
                            PrevCheck.NextElement = null;
                        }
                        else
                        {
                            PrevCheck.NextElement = CurrentCheck.NextElement;
                        }
                    }
                    else
                    {
                        //Vi går videre i listen
                        PrevCheck = CurrentCheck;
                        CurrentCheck = CurrentCheck.NextElement;
                    }
                } while (keepRunning);
            }
        }

        public int Count()
        {
            if (First == null)
            {
                return 0;
            }
            else
            {
                bool keepRunning = true;
                int count = 0;
                Element Check = First;
                do
                {
                    count++;
                    if (Check.NextElement == null)
                    {
                        keepRunning = false;
                    }
                    else
                    {
                        Check = Check.NextElement;
                    }
                } while (keepRunning);
                return count;
            }
        }

        public void Sort()
        {
            int n = this.Count();
            if (n > 1)
            {
                bool swapped;

                Element CurrentCheck;
                Element PrevCheck;
                do
                {
                    swapped = false;
                    for (int i = 2; i < n+1; i++)
                    {
                        CurrentCheck = this.GetElementObj(n);
                        PrevCheck = this.GetElementObj(n-1);

                        if (PrevCheck.Data > CurrentCheck.Data)
                        {
                            // Swap the elements
                            Element NextElement;
                            if (CurrentCheck.NextElement == null)
                            {
                                NextElement = null;
                            }
                            else
                            {
                                NextElement = CurrentCheck.NextElement;
                            }

                            CurrentCheck.NextElement = PrevCheck;

                            PrevCheck.NextElement = NextElement;

                            swapped = true;
                        }
                    }
                } while (swapped);
            }
        }

        public int GetFirst()
        {
            return First.Data;
        }
        public int GetElement(int index)
        {
            if (First != null)
            {
                bool keepRunning = true;
                int count = 0;
                Element Check = First;
                do
                {
                    count++;
                    if (count == index)
                    {
                        return Check.Data;
                    }
                    else
                    {
                        Check = Check.NextElement;
                    }

                } while (keepRunning);
            }
            return -1;
        }

        public Element GetElementObj(int index)
        {
            if (First != null)
            {
                bool keepRunning = true;
                int count = 0;
                Element Check = First;
                do
                {
                    count++;
                    if (count == index)
                    {
                        return Check;
                    }
                    else
                    {
                        Check = Check.NextElement;
                    }

                } while (keepRunning);
            }
            return null;
        }
    }
}
