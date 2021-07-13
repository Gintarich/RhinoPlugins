using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Plugin1.Clases
{
    public class Node
    {
        public Node()
        {

        }
        public Node(int number, float x_in, float y_in, float z_in)
        {
            Number = number;
            x = x_in;
            y = y_in;
            z = z_in;
        }
        [Name("Field1")]
        public int Number { get; set; }
        [Name("Field5")]
        public float x { get; set; }
        [Name("Field6")]
        public float y { get; set; }
        [Name("Field7")]
        public float z { get; set; }
    }
}
