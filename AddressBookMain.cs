using System;
using System.Collections.Generic;

namespace AddressBookUc
{
    public class AddressBookMain
    {
        private static AddressBook addressBook = new AddressBook();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book System");

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the name of the new Address Book: ");
                        string bookName = Console.ReadLine();
                        addressBook.CreateAddressBook(bookName);
                        break;

                    case "2":
                        Console.Write("Enter the name of the Address Book to select: ");
                        bookName = Console.ReadLine();
                        ManageAddressBook(bookName);
                        break;

                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void ManageAddressBook(string bookName)
        {
            while (true)
            {
                Console.WriteLine($"\nManaging Address Book: {bookName}");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search by City ");
                Console.WriteLine("6. Count by City");
                Console.WriteLine("7. Sort Contacts by Name");
                Console.WriteLine("8. Sort Contacts by City");
                Console.WriteLine("9. Sort Contacts by State");
                Console.WriteLine("10. Sort Contacts by Zip");
                Console.WriteLine("11. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Contact Details:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("City: ");
                        string city = Console.ReadLine();
                        Console.Write("State: ");
                        string state = Console.ReadLine();
                        Console.Write("Zip: ");
                        string zip = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Contact newContact = addressBook.CreateContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        addressBook.AddContact(bookName, newContact);
                        break;

                    case "2":
                        addressBook.ViewByCityOrState(bookName, false);
                        break;

                    case "3":
                        Console.Write("Enter First Name of the Contact to Edit: ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter Last Name of the Contact to Edit: ");
                        lastName = Console.ReadLine();
                        addressBook.EditContact(bookName, firstName, lastName);
                        break;

                    case "4":
                        Console.Write("Enter First Name of the Contact to Delete: ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter Last Name of the Contact to Delete: ");
                        lastName = Console.ReadLine();
                        addressBook.DeleteContact(bookName, firstName, lastName);
                        break;

                    case "5":
                        Console.Write("Enter City to Search: ");
                        city = Console.ReadLine();
                        addressBook.SearchByCityOrState(city, true);
                        break;
                   case "6":
                        addressBook.CountByCityOrState();
                        break:
                    case "7":
                        addressBook.SortByName(bookName);
                        break;
                    case "8":
                        addressBook.SortByCityStateOrZip(bookName, "city");
                        break;

                    case "9":
                        addressBook.SortByCityStateOrZip(bookName, "state");
                        break;

                    case "10":
                        addressBook.SortByCityStateOrZip(bookName, "zip");
                        break;

                    case "11":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
}
}
}

