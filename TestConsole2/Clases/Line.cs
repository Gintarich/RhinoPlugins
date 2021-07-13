using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    public class Line
    {
        public Line()
        {

        }
        public Line(int number, Node node1, Node node2)
        {
            Number = number;
            Nodes.Add(node1);
            Nodes.Add(node2);
        }
        public int Number { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
