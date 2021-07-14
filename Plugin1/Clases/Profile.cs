using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    public class Profile
    {
        //Ctor
        public Profile()
        {
            
        }
        //Atributes
        public int Number { get; set; }
        public string ProfileDescription { get; set; }
        //Private Atributes
        private string _profileName;

        //Atribute Getters/Setters
        public string ProfileName
        {
            get { return _profileName; }
        }
        //Methods
        public void SetValue()
        {
            var profilestringparts = ProfileDescription.Split(' ').ToList();

            if (profilestringparts[1].Contains('x'))
            {
                profilestringparts[1] = profilestringparts[1].Replace('x', '*');
            }

            if (profilestringparts[0] == "QRO")
            {
                _profileName = "SHS" + profilestringparts[1];
            }
            else if (profilestringparts[0] == "RRO")
            {
                _profileName = "RHS" + profilestringparts[1];
            }
            else
            {
                _profileName = profilestringparts[0] + profilestringparts[1];
            }
        }

    }
}
