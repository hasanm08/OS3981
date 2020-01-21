using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3981
{
    class Generate
    {
        public static bool SaveLRU()
        {
            List<string> vs = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                vs.Add(GenerateLRU());
            }
            vs.Add(vs.Last());
           return DataBase.SaveLRU(vs);

        }
        public static string  GenerateLRU()
        {
            return RandomString(1);
        }
        private static readonly Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool SaveMem()
        {
            List<Process> vs = new List<Process>();
            for (int i = 0; i < 25; i++)
            {
                vs.Add(new Process (GenerateMem(),random.Next(1,31),i));
            }
            return DataBase.SaveMem(vs);

        }
        public static string GenerateMem()
        {
            return RandomString(1);
        }
        public static bool SaveBank()
        {
            List<string> vs = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                vs.Add(GenerateBank());
            }
            return DataBase.SaveBank(vs);

        }
        public static string GenerateBank()
        {
            return RandomString(1);
        }
    }
}
