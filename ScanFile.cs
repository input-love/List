using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    interface IScanFile
    {
        int[] ScanFile(string nameFile, int size);
    }
    public class ScanFile : IScanFile
    {
        int[] IScanFile.ScanFile(string nameFile, int size)
        {
            if (File.Exists(@nameFile))
            {
                string line;
                int[] array = new int[size];
                using (StreamReader streamReader = new StreamReader(@nameFile))
                {
                    for (int i = 0; i < size; ++i)
                    {
                        if ((line = streamReader.ReadLine()) == null)
                        {
                            throw new Exception("Недопустимое количество элементов в файле!...");
                        }
                        else
                        {
                            array[i] = Convert.ToInt32(line);
                        }
                    }
                }
                return array;
            }
            else
            {
                throw new Exception("Нет такого файла!...");
            }
        }
    }
}
