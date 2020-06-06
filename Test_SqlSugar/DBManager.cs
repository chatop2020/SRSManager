using System;
using System.Linq;
using SqlSugar;

namespace Test_SqlSugar
{
    public static class DBManager
    {
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            DbType = DbType.Sqlite,
            ConnectionString = "DataSource=/Users/qiuzhouwei/mytest.db",
            InitKeyType = InitKeyType.Attribute,
            IsAutoCloseConnection = true,
            AopEvents = new AopEvents
            {
                OnLogExecuting = (sql, p) =>
                {
                    Console.WriteLine("pringSql:"+sql);
                    Console.WriteLine("printJson:"+string.Join(",", p?.Select(it => it.ParameterName + ":" + it.Value)));
                }
            }
        });
        
    }
}