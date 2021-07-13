using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    class MemberSetMap : ClassMap<MemberSet>
    {
        public MemberSetMap()
        {
            Map(m => m.Number).Index(0);
            Map(m => m.MemberList).Index(3);
        }
    }
}
