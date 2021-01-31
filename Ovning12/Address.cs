using System;
using System.Collections.Generic;
using System.Text;

namespace Ovning12
{
    class Address
    {
        public string StreetNameAndNumber { get; private set; }
        public string Postcode { get; private set; }
        public string City { get; private set; }
        public string AddressType { get; private set; }


        public Address(string addressType, string streetInput, string postcodeInput, string cityInput)
        {
            StreetNameAndNumber = streetInput;
            Postcode = postcodeInput;
            City = cityInput;
            AddressType = addressType;
        }

    }
}
