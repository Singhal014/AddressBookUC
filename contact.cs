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

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Address: {Address}, City: {City}, State: {State}, Zip: {Zip}, Phone: {PhoneNumber}, Email: {Email}";
        }
    }

    public class AddressBook
    {
        private Dictionary<string, List<Contact>> addressBooks = new Dictionary<string, List<Contact>>();

        // UC 1: Ability to Create Contacts
        public Contact CreateContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            return new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        // UC 2: Add a New Contact to Address Book
        public void AddContact(string bookName, Contact contact)
        {
            if (!addressBooks.ContainsKey(bookName))
            {
                addressBooks[bookName] = new List<Contact>();
            }

            // UC 7: Ensure No Duplicate Entry
            if (addressBooks[bookName].Any(c => c.FirstName.Equals(contact.FirstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(contact.LastName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Duplicate contact found! Contact not added.");
                return;
            }

            addressBooks[bookName].Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        // UC 3: Edit Existing Contact
        public void EditContact(string bookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                var contact = addressBooks[bookName].FirstOrDefault(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
                if (contact != null)
                {
                    Console.Write("Enter new Address: ");
                    contact.Address = Console.ReadLine();
                    Console.Write("Enter new City: ");
                    contact.City = Console.ReadLine();
                    Console.Write("Enter new State: ");
                    contact.State = Console.ReadLine();
                    Console.Write("Enter new Zip: ");
                    contact.Zip = Console.ReadLine();
                    Console.Write("Enter new Phone Number: ");
                    contact.PhoneNumber = Console.ReadLine();
                    Console.Write("Enter new Email: ");
                    contact.Email = Console.ReadLine();
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

        // UC 4: Delete a Contact
        public void DeleteContact(string bookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(bookName))
            {
                var contact = addressBooks[bookName].FirstOrDefault(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
                if (contact != null)
                {
                    addressBooks[bookName].Remove(contact);
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

        // UC 5: Add Multiple Persons to Address Book
        public void AddMultipleContacts(string bookName, List<Contact> contacts)
        {
            if (!addressBooks.ContainsKey(bookName))
            {
                addressBooks[bookName] = new List<Contact>();
            }

            foreach (var contact in contacts)
            {
                AddContact(bookName, contact);
            }
        }

        // UC 6: Multiple Address Books
        public void CreateAddressBook(string bookName)
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

        // UC 8: Search Person by City or State
        public void SearchByCityOrState(string search, bool isCity)
        {
            var results = addressBooks.Values
                                      .SelectMany(book => book)
                                      .Where(c => isCity ? c.City.Equals(search, StringComparison.OrdinalIgnoreCase) : c.State.Equals(search, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

            if (results.Any())
            {
                Console.WriteLine($"Contacts in {(isCity ? "City" : "State")} {search}:");
                foreach (var contact in results)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine($"No contacts found in {(isCity ? "City" : "State")} {search}.");
            }
        }
    }
