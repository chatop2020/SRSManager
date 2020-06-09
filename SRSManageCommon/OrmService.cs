using System.Diagnostics;
using FreeSql;

namespace SrsManageCommon
{
    public static class OrmService
    {
        public static IFreeSql Db = new FreeSqlBuilder()
            .UseConnectionString(DataType.Sqlite, "data source=" + Common.WorkPath + "SRSWebApi.db")
            .UseMonitorCommand(cmd => Trace.WriteLine($"线程：{cmd.CommandText}\r\n"))
            .UseAutoSyncStructure(true) //自动创建、迁移实体表结构
            .UseNoneCommandParameter(true)
            .Build();
    }
}