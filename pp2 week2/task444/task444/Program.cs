using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        public static void Place(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path); // папка инфо беремз
            string pat = directory.Parent.FullName; // полный атын пат ка енгиземз
            using (FileStream fs = File.Create(path + @"C:\Users\Admin\Desktop\qwerty\zxcv\input2.txt")) // папканин ишинде уже файл болса , оширеди болмаса басынан сизге шыгарп береди
            {
            }
            File.Copy(path + @"C:\Users\Admin\Desktop\qwerty\zxcv\input2.txt", pat + @"C: \Users\Admin\Desktop\qwerty\zxcv\input2.txt"); // бир файлдан баска файлга коширилуи
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\Desktop\qwerty\zxcv\qwert"; // папкани стринга пачка енгиземз
            Place(path);  // функцияга жверемз
            File.Delete(path + @"C:\Users\Admin\Desktop\qwerty\zxcv\input2.txt"); // жверилип болгасн оширип тастауы
        }
    }
}
