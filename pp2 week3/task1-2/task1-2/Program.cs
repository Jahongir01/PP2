using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1_2
{
    class Parts //создание класса
    {
        private int selectedItem; 
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value >= Content.Count) //если курсор опускается ниже длины
                {
                    selectedItem = 0;
                }
                else if (value < 0) // если курсор превышает длину
                {
                    selectedItem = Content.Count - 1;
                }
                else // или курсор, равный текущему месту в каталоге
                {
                    selectedItem = value;
                }
            }
        }

        public List<FileSystemInfo> Content // создать вектор для файлов
        {
            get; // дающий оператор
            set;
        }

        public void DeleteSelectedItem() // file oshiru
        {
            FileSystemInfo fileSystemInfo = Content[selectedItem]; // Текущий каталог
            if (fileSystemInfo.GetType() == typeof(DirectoryInfo)) // если каталог
            {
                Directory.Delete(fileSystemInfo.FullName, true); //удалить да
            }
            else // ili
            {
                File.Delete(fileSystemInfo.FullName); // файлды оширу
            }
            Content.RemoveAt(selectedItem);
            selectedItem--; 
        }

        public void Draw()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Content.Count; ++i)
            {
                if (i == SelectedItem) //текущий каталог или файл синего цвета
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else // где не курсор, черный
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name); // дурыс

            }
        }
        enum Type //создание типа, файл dir
        {
            File,
            Directory
        }
        class Program
        {
            static void Main(string[] args)
            {
                Type typ = Type.Directory; // бириншиден каталог
                string path = "C:/Users/Le Marguese/Desktop";
                DirectoryInfo dir = new DirectoryInfo(path);
                Stack<Parts> par = new Stack<Parts>(); // положить все это в стек LIFO
                par.Push(
                    new Parts
                    {
                        Content = dir.GetFileSystemInfos().ToList(), // каждый файл идет в список
                        SelectedItem = 0
                    });
                while (true)
                {
                    par.Peek().Draw(); //Интерфейс рисования
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); //для ключей
                    switch (consoleKeyInfo.Key)
                    {
                        case ConsoleKey.F2: // если F2, то переименуйте его, дав собственное имя
                            int y = par.Peek().SelectedItem;
                            FileSystemInfo fos = par.Peek().Content[y];
                            string chan = Console.ReadLine();
                            DirectoryInfo df = new DirectoryInfo(fos.FullName);
                            File.Move(fos.FullName, df.Parent.FullName + "/" + chan);
                            break;
                        case ConsoleKey.Delete: 
                            par.Peek().DeleteSelectedItem();
                            break;
                        case ConsoleKey.UpArrow: //Продолжается
                            par.Peek().SelectedItem--;
                            break;
                        case ConsoleKey.DownArrow: // идет вниз
                            par.Peek().SelectedItem++;
                            break;
                        case ConsoleKey.Backspace: // предыдущее направление
                            if (typ == Type.Directory)
                            {
                                par.Pop();
                            }
                            else
                            {
                                typ = Type.Directory;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            break;
                        case ConsoleKey.Enter: // вход в каталог, если файл - открыть
                            int x = par.Peek().SelectedItem;
                            FileSystemInfo fileSystemInfo = par.Peek().Content[x];
                            if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                                par.Push(
                                   new Parts
                                   {
                                       Content = directoryInfo.GetFileSystemInfos().ToList(),
                                       SelectedItem = 0
                                   });
                            }
                            else
                            {
                                Process.Start(fileSystemInfo.FullName);
                            }
                            break;
                    }
                }
            }
        }
    }
}