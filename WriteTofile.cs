using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace wordNet_project
{
    public class WriteTofile
    {
     
        public static void Write(string name  ,  string txt)
        {
            
            StreamWriter sw = new StreamWriter(name);
            sw.WriteLine(txt);
            
            sw.Close();
        }
    }
}
