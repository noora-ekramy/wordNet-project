using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace wordNet_project
{
    class MappingNounToSynsetsIDs
    {
        public static List<int> Maping_Noun_To_SynsetsIDs( Dictionary<string, List<int>> Words , string Word)
        {
            
            if (Words.ContainsKey(Word))
                return Words[Word];
            else
                return new List<int> { };
        }
    }
}
