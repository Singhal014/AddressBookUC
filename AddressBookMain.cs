using System;

namespace AddressBookUc
{
    public class AddressBookMain
    {
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
                        Contact.CreateAddressBook(bookName);
                        break;

                    case "2":
                        Console.Write("Enter the name of the Address Book to select: ");
                        string selectedBook = Console.ReadLine();
                        ManageAddressBook(selectedBook);
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
                Console.WriteLine("5. Back to Main Menu");
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
                        Contact.AddContact(bookName, firstName, lastName, address, city, state, zip, phoneNumber, email);
                        break;

                    case "2":
                        Contact.DisplayContacts(bookName);
                        break;

                    case "3":
                        Contact.EditContact(bookName);
                        break;

                    case "4":
                        Contact.DeleteContact(bookName);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

