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
        public Member(int crossection, int number, Line line, string comment)
        {
            Crossection = crossection;
            Number = number;
            Line = line;
            Comment = comment;
        }
        //public fields/properties
        public int Crossection { get; set; }
        public int Number { get; set; }
        public Line Line { get; set; }
        public string Comment { get; set; }
        public int LineNr { get; set; }
        //private fields
        private Profile _profile;
        // getters/setters

        public Profile Profile
        {
            get { return _profile; }
        }

        //Methods
        public void PopulateLines(List<Line> lines)
        {
            Line = lines.Where(x => x.Number == LineNr).ToList().ElementAt(0);
        }
        public void SetProfile (List<Profile> profiles)
        {
            _profile = profiles.Where(x => x.Number == Crossection).ToList().ElementAt(0);
        }
    }
}
