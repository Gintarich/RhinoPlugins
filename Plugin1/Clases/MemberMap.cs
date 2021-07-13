using System;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    class MemberMap : ClassMap<Member>
    {
        public MemberMap()
        {
            Map(m => m.Number).Index(0);
            Map(m => m.LineNr).Index(1);
            Map(m => m.Crossection).Index(3);
            Map(m => m.Comment).Index(15);
        }
    }
}
