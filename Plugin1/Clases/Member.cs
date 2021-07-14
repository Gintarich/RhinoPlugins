using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    public class Member
    {
        public Member()
        {

        }
        public Member(string crossection, int number, Line line, string comment)
        {
            Crossection = crossection;
            Number = number;
            Line = line;
            Comment = comment;
        }
        public string Crossection { get; set; }
        public int Number { get; set; }
        public Line Line { get; set; }
        public string Comment { get; set; }
        public int LineNr { get; set; }
        private Profile _profile;

        public Profile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }


        public void PopulateLines(List<Line> lines)
        {
            Line = lines.Where(x => x.Number == LineNr).ToList().ElementAt(0);
        }
    }
}
