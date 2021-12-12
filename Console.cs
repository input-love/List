using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    interface IConsoleIt
    {
        void Start();
    }
    public class ConsoleIt : IConsoleIt
    {
        void IConsoleIt.Start()
        {
            while (true)
            {
                PrintMenu();
                int value = Convert.ToInt32(Console.ReadLine());

                switch (value)
                {
                    case 1:
                        list.PushFront(DialogGetValue());
                        break;

                    case 2:
                        list.PushBack(DialogGetValue());
                        break;

                    case 3:
                        list.PopFront();
                        break;

                    case 4:
                        list.PopBack();
                        break;

                    case 5:
                        list.SwapHeadTail();
                        break;

                    case 6:
                        Empty();
                        break;

                    case 7:
                        PrintList();
                        break;

                    case 8:
                        AddDataFromFile();
                        break;

                    case 9:
                        RecordToFile();
                        break;

                    default:
                        return;
                }
            }
        }

        private void AddDataFromFile()
        {
            try
            {
                IScanFile scanFile = new ScanFile();

                int[] numbers = scanFile.ScanFile(DialogGetNameFile(), DialogGetCount());

                foreach (int i in numbers)
                {
                    list.PushBack(i);
                }
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
        }

        private void RecordToFile()
        {
            int[] array = new int[list.count];

            int count = 0;
            foreach (Node i in list)
            {
                array[count] = i.data;
                count++;
            }

            try
            {
                IRecordFile record = new RecordFile();

                record.Record(ref array);
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
        }

        private void Empty()
        {
            if(list.Empty())
            {
                Console.WriteLine("Пустой список");
            }
            else
            {
                Console.WriteLine("Не пустой список");
            }

        }

        private void PrintList()
        {
            foreach (Node i in list)
            {
                Console.WriteLine(i.data.ToString());
            }
        }

        private int DialogGetValue()
        {
            Console.WriteLine("Какое число добавить:");
            int value = Convert.ToInt32(Console.ReadLine());
            
            return value;
        }

        private string DialogGetNameFile()
        {
            Console.WriteLine("Введите название файла:");
            string nameFile = Console.ReadLine();

            return nameFile;
        }

        private int DialogGetCount()
        {
            Console.WriteLine("Сколько чисел считать из файла:");
            int count = Convert.ToInt32(Console.ReadLine());

            return count;
        }

        private void PrintMenu()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Что вы хотите сделать?:");
            Console.WriteLine("1.Занести число в начало списка");
            Console.WriteLine("2.Занести число в конец списка");
            Console.WriteLine("3.Удалить число из начала списка");
            Console.WriteLine("4.Удалить число из конца списка");
            Console.WriteLine("5.Поменять местами начало списка(head) и конец(tail)");
            Console.WriteLine("6.Узнать, пустой ли список");
            Console.WriteLine("7.Вывести список");
            Console.WriteLine("--------------------");
            Console.WriteLine("8.Занести массив данных из файла");
            Console.WriteLine("9.Вывести массив данных в файл");
            Console.WriteLine("--------------------");
        }

        List list = new List(); 
    }
}