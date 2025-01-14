using System;
using System.Collections.Generic;
using System.Linq;

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

        private static Dictionary<string, List<Contact>> addressBooks = new Dictionary<string, List<Contact>>();

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
        }

        // Create a new address book
        public static void CreateAddressBook(string bookName)
        {
            if (!addressBooks.ContainsKey(bookName))
            {
                addressBooks[bookName] = new List<Contact>();
                Console.WriteLine($"Address Book '{bookName}' created successfully.");
            }
            else
            {
                Console.WriteLine("Address Book already exists.");
            }
        }

        // Add a new contact to an address book, checking for duplicates
        public static bool AddContact(string bookName, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                foreach (var contact in addressBooks[bookName])
                {
                    if (contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                        contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Duplicate contact found! Contact not added.");
                        return false;
                    }
                }

                
                Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                addressBooks[bookName].Add(newContact);
                Console.WriteLine("Contact added successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Address Book not found.");
                return false;
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
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }

        
        public static void EditContact(string bookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                var contacts = addressBooks[bookName];
                var contactToEdit = contacts.FirstOrDefault(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

                if (contactToEdit != null)
                {
                    Console.Write("Enter new Address: ");
                    contactToEdit.Address = Console.ReadLine();
                    Console.Write("Enter new City: ");
                    contactToEdit.City = Console.ReadLine();
                    Console.Write("Enter new State: ");
                    contactToEdit.State = Console.ReadLine();
                    Console.Write("Enter new Zip: ");
                    contactToEdit.Zip = Console.ReadLine();
                    Console.Write("Enter new Phone Number: ");
                    contactToEdit.PhoneNumber = Console.ReadLine();
                    Console.Write("Enter new Email: ");
                    contactToEdit.Email = Console.ReadLine();
                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }

        
        public static void DeleteContact(string bookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                var contacts = addressBooks[bookName];
                var contactToDelete = contacts.FirstOrDefault(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

                if (contactToDelete != null)
                {
                    contacts.Remove(contactToDelete);
                    Console.WriteLine("Contact deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }

    }
}

