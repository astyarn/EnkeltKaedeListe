using EnkeltKædeListe;

namespace EnkeltKædeListeUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreateElement()
        {
            Element test1 = new Element(1, null); 

            Assert.Equal(1, test1.Data);
            Assert.Null(test1.NextElement);
        }

        [Fact]
        public void FirstElementInList()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            Assert.Equal(6, list.GetFirst());
        }

        [Fact]
        public void HowManyElementsInList2()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(7);
            Assert.Equal(2, list.Count());
        }

        [Fact]
        public void HowManyElementsInList5()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(6);
            list.Add(6);
            list.Add(6);
            list.Add(7);
            Assert.Equal(5, list.Count());
        }

        [Fact]
        public void RemoveAnElementInList()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(7);
            list.Remove(1);
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void RemoveCorrectElementInList()
        {
            KædeListe list = new KædeListe();
            list.Add(7);
            list.Add(6);
            list.Remove(1);
            Assert.Equal(7, list.GetFirst());
        }

        [Fact]
        public void GetAnElementInList()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(5);
            list.Add(7);
            Assert.Equal(5, list.GetElement(2));
        }

        [Fact]
        public void GetAnElementInList2()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(5);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(22);
            list.Add(11);
            Assert.Equal(8, list.GetElement(4));
        }

        [Fact]
        public void SortElementsInList()
        {
            KædeListe list = new KædeListe();
            list.Add(6);
            list.Add(5);
            list.Add(7);
            list.Sort();
            Assert.Equal(5, list.GetFirst());
            //Assert.Equal(6, list.GetElement(2));
            //Assert.Equal(7, list.GetElement(3));
        }

        [Fact]
        public void SortElementsInList2()
        {
            KædeListe list = new KædeListe();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Sort();
            Assert.Equal(1, list.GetFirst());
            //Assert.Equal(6, list.GetElement(2));
            //Assert.Equal(7, list.GetElement(3));
        }
    }
}