using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using SRSCallBackManager.Structs;
using SRSManageCommon;

namespace SRSCallBackManager
{
    [Serializable]
    public class DvrListManager
    {
        private List<DvrMessage> _dvrList;

        public List<DvrMessage> DvrList
        {
            get => _dvrList;
            set => _dvrList = value;
        }

        public DvrListManager()
        {
            DvrList= new List<DvrMessage>();
           if (Directory.Exists(Environment.CurrentDirectory + "/RecordDvr/"))
           {
               DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory + "/RecordDvr/");
               foreach (var dir in dirInfo.GetDirectories())
               {
                   if (File.Exists(dir.FullName + "DvrList.json"))
                   {
                       DvrList.AddRange(JsonHelper.FromJson<List<DvrMessage>>(dir.FullName + "DvrList.json"));
                   }
               }
           }
        }
    }
}