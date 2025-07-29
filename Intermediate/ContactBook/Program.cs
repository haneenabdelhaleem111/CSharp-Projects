using ContactBook;
using System;
using System.Collections.Generic;
using System.IO;

namespace ContactBookApp
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();
        const string filePath = "contacts.txt";

        static void Main(string[] args)
        {
            LoadContacts();

            while (true)
            {
                Console.WriteLine("\n📒 Contact Book");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ViewContacts();
                        break;
                    case "3":
                        SearchContact();
                        break;
                    case "4":
                        SaveContacts();
                        Console.WriteLine("👋 Goodbye!");
                        return;
                    default:
                        Console.WriteLine("❌ Invalid option. Try again.");
                        break;
                }
            }
        }
        //Method for adding the contacts 
        static void AddContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            contacts.Add(new Contact(name, phone));
            Console.WriteLine("✅ Contact added.");
        }
        //Method for viewing the contacts 
        static void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("📭 No contacts found.");
                return;
            }

            Console.WriteLine("\n📃 Contact List:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        //Method for searching the contacts 
        static void SearchContact()
        {
            Console.Write("🔍 Enter name to search: ");
            string search = Console.ReadLine().ToLower();

            /*contacts:list of contacts 
             * .FindAll: filters the list returning only the contact that matches
             * c: tiny function for each contact
             * rest: checks the contacts name
             * 
             */

            var results = contacts.FindAll(c => c.Name.ToLower().Contains(search));

            if (results.Count == 0)
            {
                Console.WriteLine("🙁 No contacts found.");
            }
            else
            {
                Console.WriteLine("\n📌 Results:");
                foreach (var c in results)
                {
                    Console.WriteLine(c);
                }
            }
        }
        //Method for saving the contacts to the file 
        static void SaveContacts()
        {
            //StreamWriter: to write a text to a file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var c in contacts)
                {
                    //writing the data into one line separated with  |
                    writer.WriteLine($"{c.Name}|{c.PhoneNumber}");
                }
            }

            Console.WriteLine("📁 Contacts saved to file.");
        }

        //Method for loadin the list of contacts 
        static void LoadContacts()
        {
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                {
                    contacts.Add(new Contact(parts[0], parts[1]));
                }
            }

            Console.WriteLine($"📂 Loaded {contacts.Count} contacts.");
        }
    }
}
