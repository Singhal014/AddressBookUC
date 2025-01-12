using System;

namespace AddressBookUc
{
    public class AddressBookMain
    {
        public static void Main(string[] args)
        {
                        Console.WriteLine("Enter Contact Details:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: "                        string lastName = Console.ReadLine();
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

        }
    }
}

