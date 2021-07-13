using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;

namespace TestConsole2
{
    public class Node 
    {
        public Node()
        {

        }
        public Node(float number, float x_in, float y_in, float z_in)
        {
            Number = number;
            x = x_in;
            y = y_in;
            z = z_in;
        }
        
        public double Number { get; set; }

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        /*
        private float _x;
        public double x
        {
            get { return _x; }
            set { _x = float.Parse(value.ToString()); }
        }

        private double _y;
        public double y
        {
            get { return _y; }
            set { _y = float.Parse(value.ToString()); }
        }

        private float _z;
        public float z
        {
            get { return _z; }
            set { _z = float.Parse(value.ToString()); }
        }

        */


    }
}
