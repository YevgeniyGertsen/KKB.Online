using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set;}
        public string SecondName { get; set; }
        public DateTime Birth { get; set; }
        public string IIN { get; set; }
        public string Sex { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - Birth.Year;
            }
        }
        public string FullName
        {
            get
            {
                return Name + " " + SecondName;
            }
        }
        public string ShortName
        {
            get
            {
                return string.Format("{0} {1}.", Name, SecondName[0]);
            }
        }

        public Account[] Accounts { get; set; }        
    }
}
