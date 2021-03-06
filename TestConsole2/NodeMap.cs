using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole2.TypeConverter;

namespace TestConsole2
{
    public class NodeMap : ClassMap<Node>
    {

        public NodeMap()
        {
            Map(m => m.Number).Index(0);
            Map(m => m.x).Index(4);
            Map(m => m.y).Index(5);
            Map(m => m.z).Index(6);
        }
    }
}
