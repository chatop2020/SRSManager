using System.Diagnostics;
using FreeSql;

namespace Test_FreeSql
{
    public static class DBManager
    {
        public static IFreeSql fsql = new FreeSqlBuilder()
            .UseConnectionString(DataType.Sqlite, "data source=/Users/qiuzhouwei/mytest.db")
            .UseMonitorCommand(cmd => Trace.WriteLine($"线程：{cmd.CommandText}\r\n"))
            .UseAutoSyncStructure(true)//自动创建、迁移实体表结构
            .UseNoneCommandParameter(true)
            .Build();
    }
}