using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using Rhino.Geometry;

namespace Plugin1.Clases
{
    public class Node
    {
        public Node()
        {

        }
        public Node(int number, double x_in, double y_in, double z_in)
        {
            Number = number;
            x = x_in;
            y = y_in;
            z = z_in;
        }
        public int Number { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public void Magnify()
        {
            x = x * 1000;
            y = y * 1000;
            z = z * 1000;
        }
        public void Flip()
        {
            z = -z;
        }
        public Point3d GetRhinoPoint()
        {
            Point3d rPoint = new Point3d();
            rPoint.X = x;
            rPoint.Y = y;
            rPoint.Z = z;

            return rPoint;
        }
    }
}
