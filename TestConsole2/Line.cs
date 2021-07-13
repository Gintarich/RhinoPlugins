using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2
{
    public class Line
    {
        public Line()
        {

        }
        public Line(int number, int nodenumber1, int nodenumber2)
        {
            Number = number;
            _nodeNames[0]=(nodenumber1);
            _nodeNames[1]=(nodenumber2);
        }
        public int Number { get; set; }
        public Node StartPoint { get; set; }
        public Node EndPoint { get; set; }


        private int[] _nodeNames;

        public string SetNodes
        {
            get
            {
                return _nodeNames.ToString();
            }
            set 
            {
                var st = value.Split(',');
                _nodeNames = Array.ConvertAll(st, item => int.Parse(item));
            }
        }

        public void PopulateNodes(List<Node> nodes)
        {
            StartPoint = nodes.Where(x => x.Number == _nodeNames[0]).ToList().ElementAt(0);
            EndPoint = nodes.Where(x => x.Number == _nodeNames[0]).ToList().ElementAt(1);
        }

    }
}
