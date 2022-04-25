using System;
using System.Collections.Generic;
using System.Text;

namespace wordNet_project
{
    class MappingSynsetsIDToNouns
    {
        public static List<string> Mapping_SynsetsID_To_Nouns(Dictionary<int, List<string>> SynsetsID, int SynsetID)
        {

            if (SynsetsID.ContainsKey(SynsetID))
                return SynsetsID[SynsetID];
            else
                return new List<string> { };
        }
    }
}
