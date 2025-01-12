using System;
using System.Collections.Generic;

namespace AddressBookUc
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        public static void AddContact(string bookName, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                addressBooks[bookName].Add(newContact);
                Console.WriteLine("Contact added successfully.");
            }
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }

        public static void DisplayContacts(string bookName)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                var contacts = addressBooks[bookName];
                if (contacts.Count == 0)
                {
                    Console.WriteLine("No contacts to display.");
                    return;
                }

                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State}, {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine();
                }
            }
        }
    }
}
