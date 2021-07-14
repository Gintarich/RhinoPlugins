using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.Clases
{
    class Profile
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
            set 
            { 
                var profilestringparts = ProfileDescription.Split(' ').ToList();
                if (profilestringparts[0]=="QRO")
                {
                    _profileName = "SHS" + profilestringparts[1];
                }
                if (profilestringparts[0] == "RRO")
                {
                    _profileName = "RHS" + profilestringparts[1];
                }
                else
                {
                    _profileName = profilestringparts[0] + profilestringparts[1];
                }
            }
        }
        //Methods


    }
}
