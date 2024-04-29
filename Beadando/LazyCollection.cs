using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class LazyCollection
    {
        private Lazy<List<int>> lazyList;

        public LazyCollection()
        {
            lazyList = new Lazy<List<int>>(() =>
            {
                
                List<int> list = new List<int>();

                for (int i = 1; i <= 20; i++)
                {
                    list.Add(i);
                }

                return list;
            });

        }


        public void Loading()
        {
            Console.Clear();
            Console.Write("Loading");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.WriteLine("Sikeres töltés");
            Thread.Sleep(4000);
        }

        public bool IsOkay()
        {
            if (lazyList.IsValueCreated)
                return true;
            else
                return false;
        }
        public void YouAreFinallyAwake()
        {
            var ebreszto = lazyList.Value;
            //Abszolut nem használom semmire, de felébreszti
        }
        public void AddMoreLazy()
        {
            lazyList.Value.Add(1);
        }
        public void LazyAddInput(int input)
        {
            lazyList.Value.Add(input);
        }
        public void LazyKiiratas()
        {
            foreach (var item in lazyList.Value)
            {
                Thread.Sleep(100);
                Console.WriteLine(item);
            }
        }
        public void RemoveFirstElement()
        {
            lazyList.Value.RemoveAt(0);
        }

        public void ClearList()
        {
            lazyList.Value.Clear();
        }

        public void SortList()
        {
            lazyList.Value.Sort();
        }

        public int ListCount()
        {
            return lazyList.Value.Count;
        }

        public bool ContainsElement(int element)
        {
            return lazyList.Value.Contains(element);
        }

        public int SumOfElements()
        {
            int sum = 0;
            foreach (var item in lazyList.Value)
            {
                sum += item;
            }
            return sum;
        }


    }
}




