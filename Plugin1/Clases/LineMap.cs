using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    class LineMap : ClassMap<Line>
    {
        public LineMap()
        {
            Map(m => m.Number).Index(0);
            Map(m => m.SetNodes).Index(2);
        }
    }
}
