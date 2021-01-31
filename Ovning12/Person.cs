using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Ovning12
{
    class Person
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }


        public List<Address> Addresses { get; private set; }

       

        //public Address HomeAddress { get; private set; }
        //public Address WorkAddress { get; private set; }



        public Person(string nameInput, string phoneNumberInput = "N/A", string emailInput = "N/A")
        {
            Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nameInput.ToLower());
            PhoneNumber = phoneNumberInput;
            Email = emailInput.ToLower();
            Addresses = new List<Address>();
        }

        public void ChangeInfo(string newName, string newNumber, string newEmail)
        {
            if (newName.Length > 0)
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newName.ToLower());
            if (newNumber.Length > 0)
                PhoneNumber = newNumber;
            if (newEmail.Length > 0)
                Email = newEmail.ToLower();
        }

        public void AddAdress(string addressType, string streetInput, string postcodeInput, string cityInput)
        {
            //Address newAddress = new Address(streetInput, postcodeInput, cityInput);

            Addresses.Add(new Address(addressType, streetInput, postcodeInput, cityInput)); //CRASHAR HÄR


        }

    }
}
