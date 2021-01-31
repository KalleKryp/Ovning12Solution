using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ovning12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> contacts = new List<Person>();
            contacts.Add(new Person("Kalle", "012345068", "kalle@mail.com"));
            contacts.Add(new Person("Anna", "098355096", "anna@mail.com"));
            contacts.Add(new Person("Simon", "098915048", "dgfgfg@mail.com"));
            contacts.Add(new Person("Camilla", "598345198", "987@mail.com"));
            contacts.Add(new Person("Olle", "098388898", "HEHE@mail.com"));
            bool loopMenu = true;

            do
            {
                Console.Clear();
                Console.WriteLine("LIST OF CONTACTS");
                Console.WriteLine();
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].Name} \t {contacts[i].PhoneNumber} \t {contacts[i].Email}");
                }
                Console.WriteLine();
                Console.WriteLine("[1] Add contact");
                Console.WriteLine("[2] Remove contact");
                Console.WriteLine("[3] Sort contacts");
                Console.WriteLine("[4] Edit contact");
                Console.WriteLine("[5] Add address to contact");
                Console.WriteLine("[0] End program");

                var menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D0:
                        loopMenu = false;
                        break;
                    case ConsoleKey.D1:
                        contacts = AddContact(contacts);
                        loopMenu = true;
                        break;
                    case ConsoleKey.D2:
                        contacts = RemoveContact(contacts);
                        loopMenu = true;
                        break;
                    case ConsoleKey.D3:
                        contacts = SortContact(contacts);
                        loopMenu = true;
                        break;
                    case ConsoleKey.D4:
                        contacts = EditContact(contacts);
                        loopMenu = true;
                        break;
                    case ConsoleKey.D5:
                        contacts = AddAdress(contacts);
                        loopMenu = true;
                        break;
                    default:
                        loopMenu = true;
                        break;
                }
            } while (loopMenu);

        }

        private static List<Person> AddAdress(List<Person> contacts)
        {
            ConsoleKey choice;
            do
            {
                Console.Clear();
                Console.WriteLine("LIST OF CONTACTS - Add Address");
                Console.WriteLine();
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].Name} \t {contacts[i].PhoneNumber} \t {contacts[i].Email}");
                }

                Console.WriteLine();
                Console.Write("Enter the name of the contact you want to give an adress: ");
                string contactToEdit = Console.ReadLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    if (contactToEdit == contacts[i].Name)
                    {

                        Console.Write($"What address do you want to add? I.e. work address, home address. ");
                        string addressType = Console.ReadLine();
                        Console.Write($"Enter street name and number: ");
                        string street = Console.ReadLine();
                        Console.Write($"Enter postcode: ");
                        string postcode = Console.ReadLine();
                        Console.Write($"Enter city: ");
                        string city = Console.ReadLine();


                        contacts[i].AddAdress(addressType, street, postcode, city);
                        break;
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Do you want to add an address to another contact? Press [ENTER], otherwise press any key.");
                choice = Console.ReadKey(true).Key;


            } while (choice == ConsoleKey.Enter);
            return contacts;

        }

        private static List<Person> EditContact(List<Person> contacts)
        {
            ConsoleKey choice;
            do
            {
                Console.Clear();
                Console.WriteLine("LIST OF CONTACTS - Edit Contact");
                Console.WriteLine();
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].Name} \t {contacts[i].PhoneNumber} \t {contacts[i].Email}");
                }

                Console.WriteLine();
                Console.Write("Enter the name of the contact you want to edit: ");
                string contactToEdit = Console.ReadLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    if (contactToEdit == contacts[i].Name)
                    {
                        Console.Write($"Enter new name for {contacts[i].Name}: ");
                        string newName = Console.ReadLine();
                        Console.Write($"Enter new phone number to replace { contacts[i].PhoneNumber}: ");
                        string newNumber = Console.ReadLine();
                        Console.Write($"Enter new email adress to replace { contacts[i].Email}: ");
                        string newEmail = Console.ReadLine();


                        contacts[i].ChangeInfo(newName, newNumber, newEmail);
                        break;
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Do you want to edit another contact? Press [ENTER], otherwise press any key.");
                choice = Console.ReadKey(true).Key;


            } while (choice == ConsoleKey.Enter);
            return contacts;
        }

        private static List<Person> SortContact(List<Person> contacts)
        {
            Console.Clear();
            Console.WriteLine("LIST OF CONTACTS - Sort Contacts");
            List<Person> sortedContacts = contacts.OrderBy(o => o.Name).ToList();
            Console.WriteLine("List sorted. New order: ");
            Console.WriteLine();
            for (int i = 0; i < sortedContacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedContacts[i].Name} \t {sortedContacts[i].PhoneNumber} \t {sortedContacts[i].Email}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey(true);
            return sortedContacts;
        }

        private static List<Person> AddContact(List<Person> contacts)
        {
            ConsoleKey choice;
            do
            {
                Console.Clear();
                Console.WriteLine("LIST OF CONTACTS - Add Contact");
                Console.WriteLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].Name} \t {contacts[i].PhoneNumber} \t {contacts[i].Email}");
                }
                Console.WriteLine();
                Console.WriteLine("Add a new contact");
                Console.WriteLine();
                Console.Write("Name: ");
                string tempName = Console.ReadLine();
                Console.Write("Phone number: ");
                string tempNum = Console.ReadLine();
                Console.Write("Email adress: ");
                string tempEmail = Console.ReadLine();

                contacts.Add(new Person(tempName, tempNum, tempEmail));

                Console.WriteLine();
                Console.WriteLine("Do you want to add another contact? Press [ENTER], otherwise press any key.");
                choice = Console.ReadKey(true).Key;


            } while (choice == ConsoleKey.Enter);
            return contacts;
        }

        private static List<Person> RemoveContact(List<Person> contacts)
        {
            ConsoleKey choice;
            do
            {
                Console.Clear();
                Console.WriteLine("LIST OF CONTACTS - Remove Contact");
                Console.WriteLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].Name} \t {contacts[i].PhoneNumber} \t {contacts[i].Email}");
                }

                Console.WriteLine();
                Console.Write("Enter the name of the contact you want to remove: ");
                string unwantedContact = Console.ReadLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    if (unwantedContact == contacts[i].Name)
                    {
                        contacts.Remove(contacts[i]);
                        break;
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Do you want to remove another contact? Press [ENTER], otherwise press any key.");
                choice = Console.ReadKey(true).Key;


            } while (choice == ConsoleKey.Enter);
            return contacts;
        }
    }
}
