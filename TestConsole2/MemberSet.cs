using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2
{
    public class MemberSet
    {
        public MemberSet(int number, List<Member> members)
        {
            Number = number;
            Members = members;
        }
        public int Number { get; set; }
        public List<Member> Members { get; set; }
    }
}
