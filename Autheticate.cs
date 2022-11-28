using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mohsan
{
    internal class autheticate
    {
        private StreamReader Reader;

        private List<string> LogData;

        public autheticate()
        {

        }

        public List<string> attainUser()
        {
            // fetches the data from text file using # as the delimiter
            Reader = new StreamReader("Credentials.txt", true);
            LogData = new List<string>();
            while (!Reader.EndOfStream)
            {
                string text = Reader.ReadToEnd();//read till the end of the text file
                string[] text2 = text.Split('#');
                LogData.Add(text2[0]);
                LogData.Add(text2[1]);
            }
            Reader.Close();
            return LogData;
        }




    }
}
