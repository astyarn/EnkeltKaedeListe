using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EnkeltKædeListe
{
    public class KædeListe
    {
        public Element? First { get; set; }

        public KædeListe()
        {
            First = null;
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
            bool Swapped;

            if (n > 1) 
            {
                do
                {
                    Swapped = false;
                    for (int i = 1; i < n; i++)
                    {
                        //Check if a previous element exists
                        Element N;
                        if ((i - 1) <= 0)
                        {
                            N = null;
                        }
                        else
                        {
                            N = GetElementObj(i - 1);
                        }
                    
                        Element a = GetElementObj(i);
                        Element b = GetElementObj(i+1);

                        if (a.Data > b.Data)
                        {
                            Element tempC;
                            if (b.NextElement != null)
                            {
                                tempC = b.NextElement;
                            }
                            else
                            {
                                tempC = null;
                            }
                            b.NextElement = a;
                            a.NextElement = tempC;

                            //Check if one of the swapped elements is now the first and set it as first
                            if (i == 1)
                            {
                                this.First = b;
                            }

                            //If there was an element before current compred one swapped change the pointer of it
                            if (N != null)
                            {
                                N.NextElement = b;
                            }
                            Swapped = true;
                        }
                    
                    }
                } while (Swapped);
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

        public string Print()
        {
            string print = string.Empty;

            int n = this.Count();

            for (int i = 1; i < n+1; i++ )
            {
                Element t = this.GetElementObj(i);
                print += Convert.ToString(t.Data);
                if (t.NextElement != null)
                {
                    print += ",";
                }  
            }

            return print;
        }
    }
}
