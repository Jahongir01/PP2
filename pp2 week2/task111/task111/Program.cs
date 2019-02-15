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
        public static void Palindrome(string pal)
        {
            char[] str = new char[pal.Length]; 
            bool ok = true; // булевой операцияны истеп , полиндромба или палиндром емеспа екенин табамз
            for (int i = 0; i < str.Length; i++) // массив чардан турадтын исеймиз
            {
                str[i] = pal[i]; // стринг массивтен бир бир чарды алп , баска массивке енгисемиз
            }
            for (int i = 0; i < str.Length; i++) // массив чардан
            {
                if (str[i] == str[str.Length - i - 1]) // кери айналдырып салыстрамз
                {
                    ok = true; // дурс болса , true га айналады
                    continue;
                }
                else 
                {
                    ok = false; // дурс емес болса , false га айналады
                    break;
                }
            }
            if (ok) // полидром болса 
            {
                Console.WriteLine("Yeah, that is palindrome!");
            }
            else // болмаса
            {
                Console.WriteLine("Sorry, it is not.");
            }
        }
        static void Main(string[] args)
        {
            string pal = Console.ReadLine(); //стринг
            Palindrome(pal); // стринг функцияга лактырдым
        }
    }
}