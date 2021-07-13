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
    }
}
