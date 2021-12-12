using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    interface IRecordFile
    {
        void Record(ref int[] array);
    }

    public class RecordFile : IRecordFile
    {
        void IRecordFile.Record(ref int[] array)
        {
            string fileName = @"result.txt";
            try
            {
                using (StreamWriter fout = new StreamWriter(fileName, false))
                {
                    foreach(int i in array)
                    {
                        fout.Write($"{i}\n");
                    }
                }
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
    }
}
