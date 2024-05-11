using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace My_Awesome_Program
{
    class Book
    {
        public string name;
        public string author;
        public int serial_no;

        public Book(string name, string author, int serial_no)
        {
           this.name = name;
           this.author = author;
           this.serial_no = serial_no;
        }
        public override string ToString()
        {
            return $"Name: {name}, Author: {author}, Serial No: {serial_no}";
        }
        
        
    }
    class Library
    {
        private List<Book> library;
        
        public Library()
        {
            library = new List<Book>();
        }
        public void AddBook(Book book)
        {
            library.Add(book);
        }
        public void DeleteBook(string name)
        {
            bool found = false;
            for (int i = 0; i< library.Count; i++){
                if (library[i].name == name)
                {
                    library.RemoveAt(i);
                    Console.WriteLine($"You have successfully deleted {name}");
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                Console.WriteLine("Sorry cannot find book.");
            }
        }
        public void DisplayBook()
        {
            foreach (var book in library)
            {
               Console.WriteLine(book.ToString());
            }
        }
        public void searchBook(string name)
        {
            bool found = false;
            foreach (var book in library)
            {
                if(book.name == name)
                {
                     Console.WriteLine(book);
                     found = true;
                }
                
            }
            if(!found)
            {
                Console.WriteLine("Book not found!");
            }
        }

    }
    

    class Program
    {
       static void Main(string[] args)
        {
            Library library = new Library();
            void displayMenu()
            {
                Console.WriteLine("\nLibrary Menu");
                Console.WriteLine("--------------");
                Console.WriteLine("1. Add Books");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
            
                Console.WriteLine("Enter menu choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addBooktoLibrary();
                        break;
                    case 2:
                        displayAllBooks();
                        break;
                    case 3:
                        Console.WriteLine("What book are you looking for? ");
                        string name = Console.ReadLine();
                        retrieve(name);
                        break;
                    case 4:
                        delete();
                        break;
                    case 5:
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Choose a valid choice");
                        break;   
                }
            }
            void addBooktoLibrary()
            {
                

                // Prompt the user to enter book information
                Console.WriteLine("Enter book information:");
                while (true)
                {
                    Console.Write("Name (or type 'exit' to finish): ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "exit")
                      break;
                      

                    Console.Write("Author: ");
                    string author = Console.ReadLine();
  
                    Console.Write("Serial No: ");
                    int serialNo;
                    while (!int.TryParse(Console.ReadLine(), out serialNo))
                    {
                        Console.WriteLine("Please enter a valid serial number.");
                        Console.Write("Serial No: ");
                    }

                    // Add the book to the library
                    library.AddBook(new Book(name, author, serialNo));
                    break;
                }
                displayMenu();
            }
            void displayAllBooks()
            {
                
                // Display the books in the library
                Console.WriteLine("\nBooks in the library:");
                library.DisplayBook();
                displayMenu();

            }
            void retrieve(string name)
            {   
                //Searches for book in library 
                library.searchBook(name);
                displayMenu();
            }

            void delete()
            {
                Console.WriteLine("What book do you wish to delete?: ");
                string name = Console.ReadLine();
                //Deletes book from library
                library.DeleteBook(name);
                displayMenu();
            }   
            
            Console.WriteLine("Welcome to Your Library");
            displayMenu();
        }
    }
}