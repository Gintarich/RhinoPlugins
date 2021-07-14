using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    public class MemberSet
    {
        public MemberSet()
        {
            Members = new List<Member>();
        }
        public MemberSet(int number, string members)
        {
            Members = new List<Member>();
            Number = number;
            MemberList = members;
        }
        // Public properties
        public int Number { get; set; }
        public string MemberList { get; set; }
        public List<Member> Members { get; set; }
        // Private properties
        private Line _line;


        // Setters/Getters
        public Line Line
        {
            get { return _line; }
        }
        // Methods
        public void PopulateMembers(List<Member> members)
        {
            var membernames = MemberList.Split(',').ToList();
            var copyList = new List<string>();
            foreach (var member in membernames)
            {
                copyList.Add(member);
            }
            foreach( var member in copyList)
            {
                if (member.Contains('-'))
                {
                    IEnumerable<int> numbersBetween ;
                    var spltstr = member.Split('-').ToList();
                    int int1 = int.Parse(spltstr[0]);
                    int int2 = int.Parse(spltstr[1]);
                    if (int1<int2)
                    {
                        numbersBetween = Enumerable.Range(int1, int2 - int1 + 1);
                    }
                    else
                    {
                        numbersBetween = Enumerable.Range(int2, int1 - int2 + 1);
                    }
                    
                    foreach (var num in numbersBetween)
                    {
                        membernames.Add(num.ToString());
                    }
                    membernames.Remove(member);
                }
            }
            foreach(var member in membernames)
            {
                var current = int.Parse(member);
                var currentmember = members.Where(x => x.Number == current).ToList().ElementAt(0);
                Members.Add(currentmember);
                members.Remove(currentmember);
            }
        }

        public void SetLines()
        {
            List<Point3d> rpoint = new List<Point3d>();
            
            foreach (var member in Members)
            {
                var pt1 = member.Line.StartPoint.GetRhinoPoint();
                var pt2 = member.Line.EndPoint.GetRhinoPoint();
                rpoint.Add(pt1);
                rpoint.Add(pt2);
            }
            var pointArray = Point3d.SortAndCullPointList(rpoint, 20);
            Line line = new Line{ StartPoint = new Node{x= pointArray[0].X, y=pointArray[0].Y, z=pointArray[0].Z }, 
                EndPoint = new Node() { x = pointArray.Last().X, y = pointArray.Last().Y, z = pointArray.Last().Z } };
            _line = line;
        }
    }
}
