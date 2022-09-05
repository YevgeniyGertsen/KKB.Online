using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class Address
    {
        public Address()
        {

        }

        public Address(string Country, string Street, string House)
        {
            this.Country = Country;
            this.Street = Street;
            this.House = House;
        }

        public string Country { get; set; }
        public string Street { get; set; }
        public string House { get; set; }        
    }
}