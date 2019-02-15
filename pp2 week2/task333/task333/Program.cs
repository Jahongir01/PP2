using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task2
{
    class Program
    {
        public static void Level(int l)
        {
            for (int i = 0; i < l; i++)
            {
                Console.Write(" "); // пустой пробел 
            }
        }
        public static void Show(string path, int le)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            foreach (FileSystemInfo fs in fileSystemInfos)
            {
                if (fs.GetType() == typeof(DirectoryInfo))
                {
                    if (fs.Name.StartsWith(".")) // файл болса карамаймз
                    {
                        continue;
                    }
                    else // папка болса
                    {
                        Level(le); // алдына пробел бир лет шыгады
                        Console.WriteLine(fs.Name); // папканын аты жони
                        Show(path + "/" + fs.Name, le + 1); 
                    }
                }
                else // файл босла
                {
                    if (fs.Name.StartsWith(".")) // фалдайн кейн точка турса карамаймыз
                    {
                        continue;
                    }
                    else 
                    {
                        Level(le); // пробел бир лет кобейеди
                        Console.WriteLine(fs.Name); // файлды аты жони
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\Desktop\pp2 week2"; // стринг пачка папкидеги информацияны жверемз
            Show(path, 0); //функцияга лактырамз
        }
    }
}
