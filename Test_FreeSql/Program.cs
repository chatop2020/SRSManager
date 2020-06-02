#nullable enable
using System;
using System.Collections.Generic;

namespace Test_FreeSql
{
    class Program
    {
        static long Insert(Module obj)
        {
            return DBManager.fsql.Insert(obj).ExecuteIdentity();
        }

        static int Update(Module obj)
        {
            return DBManager.fsql.Update<Module>()
                .Set(b => b.Str, obj.Str)
                .Where(b => b.Id == obj.Id)
                .ExecuteAffrows();
        }

        static int Delete(Module obj)
        {
            return DBManager.fsql.Delete<Module>().Where(b => b.Id == obj.Id).ExecuteAffrows();
        }

        static Module Select(long id)
        {
            return DBManager.fsql.Select<Module>().Where(b => b.Id == id).First();
        }

        static List<Module> SelectAll()
        {
            return DBManager.fsql.Select<Module>().ToList();
        }

        public static string? GetIngestRtspMonitorUrlIpAddress(string url)
        {
            try
            {
                Uri link = new Uri(url);
                return link.Host;
            }
            catch
            {
                return "";
            }
        }

        static void Main(string[] args)
        {
            Module a = new Module()
            {
                End = DateTime.Now,
                Start = DateTime.Now.AddDays(1),
                Str = "这是测试",
                Type = Strtype.str1,
            };

            a.Id = Insert(a);
            a.Str = "this is a test";
            Console.WriteLine(Update(a));
            Console.WriteLine(Delete(a));
            Console.WriteLine(a.ToString());
            Console.WriteLine(Select(1).ToString());
            var list = SelectAll();
            if (list != null)
            {
                foreach (var obj in list)
                {
                    Console.WriteLine(obj.ToString());
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}