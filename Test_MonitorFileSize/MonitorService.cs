using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Test_MonitorFileSize
{
    public class MonitorService
    {
        private static int _limitTimes = 0;
        private static BlockingCollection<byte> _monintorList = new BlockingCollection<byte>(500);

        private void Run()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var value in _monintorList.GetConsumingEnumerable())
                {
                    Thread.Sleep(100);
                }
            });   
        }
        
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
Console.WriteLine(e.Name);
            if (_monintorList.Count == _monintorList.BoundedCapacity)
            {
                _limitTimes++;
            }

            if (_limitTimes > 500)
            {
                throw  new Exception("异常增长");
            }
            
                Console.Write(_monintorList.Count+",");
   
            _monintorList.Add(1); 
            Console.Write(1+",");
        }

     
        public MonitorService()
        {
            
            new Thread(new ThreadStart(delegate

            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message+"\r\n"+ex.StackTrace);
                }
            })).Start();
            
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "/tmp";
            
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite 
                                                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.IncludeSubdirectories = false;
            watcher.Filter = "*.txt";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
            
            Console.WriteLine("Press /'q/' to quit the sample.");
            int i = 0;
            while (true)
            {
                File.WriteAllText(@"/tmp/data.txt","aaaa");
                Console.Write(i+",");
               
                
            }
        }        
    }
}