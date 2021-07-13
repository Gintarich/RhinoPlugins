using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2
{
    public class Member
    {
        public Member()
        {

        }
        public Member(int crossection, int number, int linenr, string comment)
        {
            Crossection = crossection;
            Number = number;
            LineNr = linenr;
            Comment = comment;
        }
        public int Crossection { get; set; }
        public int Number { get; set; }
        public int LineNr { get; set; }
        public string Comment { get; set; }
    }
}
