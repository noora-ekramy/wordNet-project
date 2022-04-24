using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace wordNet_project
{
    class ReadFromFile
    {
        public static List<string> Read_From_File(string File_Name)
        {
            List<string> All_Lines = new List<string>();
            FileStream file;
            StreamReader sr;
            string line;
            //opeing file
            file = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            line = sr.ReadLine();
            while (line!=null)
            {
                All_Lines.Add(line);
                line = sr.ReadLine();
            }
            return All_Lines;
        }
    }
}
