using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise1
{
    class Program
    {
        static List<int> primes = new List<int>(); // интеджерден турадн лист исеймиз , лист дегенимиз ол бирнеше интеджерди кабылдайды
        static string[] str; //
        static void Give(string path)
        {
            using (StreamReader sr = new StreamReader(path)) //пачтагы стринги окып ср га тенестремиз
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    str = line.Split(); // опирация сплит , арагын пробелмен боледи
                }
                sr.Close(); // close
            }
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\Desktop\qwerty\asdfg\input.txt"; // 
            Give(path); // сринг беремз
            for (int i = 0; i < str.Length; i++)
            {
                if (int.Parse(str[i]) == 1) // сринг тагы интеджер 1ден киши болса , карамаймз , сразу оширемиз
                {
                    continue;
                }
                else if (int.Parse(str[i]) == 2 || int.Parse(str[i]) == 3) //  2 жане 3ке тен болса , ол друс , прайм болады
                {
                    primes.Add(int.Parse(str[i])); // массивтеги стрингарды интеджерге айналдырып , праймска тиркеймиз
                    
                    continue;
                }
                for (int k = 2; k <= int.Parse(str[i]); k++) // форкамен шугеримзде 
                {
                    if (int.Parse(str[i]) % k == 0 && int.Parse(str[i]) != k) // если ол 0 га жане 2ге тен болмаса карамаймз
                    {
                        break;
                    }
                    else if (int.Parse(str[i]) == k)  // тен болса
                    {
                        primes.Add(int.Parse(str[i]));
                        break;
                        
                    }
                }
            }
            StreamWriter sw = new StreamWriter(@"C:\Users\Admin\Desktop\qwerty\output.txt"); // шыгарулы
            foreach (int w in primes)
            {
                sw.Write(w + " "); // прайм сандарды енгизуи 
            }
            sw.Close(); // жабамз файлды
        }
    }
}