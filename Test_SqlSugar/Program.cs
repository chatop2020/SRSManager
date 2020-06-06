using System;

namespace Test_SqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            DBManager.db.DbMaintenance.CreateDatabase(); //建库
            var dt = DBManager.db.Ado.GetDataTable("select 1"); //测试
            DBManager.db.CodeFirst.InitTables(typeof(DvrDayTimeRange),typeof(StreamDvrPlan));//建表
            
            /*DBManager.db.Insertable<>()*/
            
            Console.WriteLine(dt);
            Console.WriteLine("Hello World!");
        }
    }
}