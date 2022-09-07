using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class User
    {
        public personal_data personal_data { get; set; }
    }
    public class personal_data
    {
        public int UserId { get; set; }
        public string LastName { get; set;}
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Iin { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string ShortName
        {
            get
            {
                return string.Format("{0} {1}.", FirstName, LastName[0]);
            }
        }

        public Account[] Accounts { get; set; }        
    }
}
