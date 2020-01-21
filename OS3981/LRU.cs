using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3981
{
    class LRU
    {
        public string Name { get; set; }
        public int Value { get; set; }
        static int  s = 3;
        public static List<LRU> Pages = new List<LRU>(s);
        

        public LRU(string name)
        {
            if (hasplace())
            {
                Pages.Add(new LRU(name, 0));
                AddAll(name);
                return;
            }
            if (Contain(name))
            {
               
                return;
            }
            else
            {
                Kickout(name);
            }
        }

         LRU(string name, int v) 
        {
            this.Value = v;
            Name = name;
        }

        bool Contain(string name)
        {
            foreach (LRU item in Pages)
            {
                if (item.Name==name)
                {
                    item.Value = 0;
                    AddAll(name);
                    return true;
                }
            }
            return false;
        }
        void AddAll(string name)
        {
            foreach (LRU item in Pages)
            {
                if (item.Name != name)
                {
                    item.Value++;
                }
            }
        }
        void Kickout(string name)
        {
            int max = -1;
            int index=0;
            for (int i = 0; i < Pages.Count; i++)
            {
                if (max<Pages[i].Value)
                {
                    max = Pages[i].Value;
                    index = i;
                }
            }
            Pages[index].Name = name;
            Pages[index].Value = 0;
            AddAll(name);
        }
        bool hasplace()
        {
            return (Pages.Count < s);
        }
        public static string GetPages()
        {
            string res="";
            foreach (var item in Pages)
            {
                res += item.ToString()+"\n";
            }
            res += ("------------------\n");
            return res;
        }
        public override string ToString()
        {
            return Name+" ("+Value.ToString()+")";
        }
    }
}
