using System;
using FreeSql.DataAnnotations;

namespace Test_FreeSql
{
    public enum Strtype
    {
        str1,
        str2
    }

    public class Module
    {
        [Column(IsIdentity = true)] public long Id { get; set; }

        public string Str { get; set; }
        [Column(MapType = typeof(string))] public Strtype Type { get; set; }


        public DateTime Start { get; set; }


        public DateTime End { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Str)}: {Str}, {nameof(Type)}: {Type}, {nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }
    }
}