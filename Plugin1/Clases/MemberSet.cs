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
        public int Number { get; set; }
        public string MemberList { get; set; }
        public List<Member> Members { get; set; }

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
    }
}
