
using System;
using System.Collections.Generic;
using System.Text;


namespace OOP_Classes
{

    public enum BookStatus
    {
        Available,
        Borrowed,
        Reserved
    }
    public class Program
    {

        static void Main(string[] args)
        {
            List<Book> library = new List<Book>();

            Dictionary<string, Book> catalog = new Dictionary<string, Book>();

            HashSet<string> borrowedISBNs = new HashSet<string>();

            string[][] shelves = new string[4][];

            shelves[0] = new string[5];
            shelves[1] = new string[8];
            shelves[2] = new string[6];
            shelves[3] = new string[4];


            Console.WriteLine("=====LIBRARY===== \nChoose the Function you want :");
            Console.WriteLine("(1) Add Book");
            Console.WriteLine("(8) exit");

            int choose = int.Parse(Console.ReadLine());

            //========================menu=======================
            bool exit = false;
            while (!exit)
            {
                switch (choose)
                {

                    case 1:
                        {
                            Console.WriteLine("Enter book isbn you want to add:");
                            string isbn_add = Console.ReadLine();
                            Console.WriteLine("Enter book Title you want to add:");
                            string Title_add = Console.ReadLine();
                            Console.WriteLine("Enter Author Name of the book you want to add:");
                            string Author_add = Console.ReadLine();
                            AddBook(library, catalog, shelves, isbn_add, Title_add, Author_add);
                            break;

                        }
                    case 8:
                        {
                            exit = true;
                            break;
                        }
                    default:
                        break;
                }

            }


        }
        //==================================ADD BOOK FUNCTION==================================
        //problem in word static
        static void AddBook(List<Book> library, Dictionary<string, Book> catalog,string[][] shelves, string isbn, string title, string author)
        {

            if (catalog.TryGetValue(isbn, out Book book))
            {
                Console.WriteLine("\"ISBN already exists.\"");
                return;
            }
            else
            {
                Book newbook = new Book(isbn, title, author);
                library.Add(newbook);
                catalog[isbn] = newbook;
                bool flag = false;
                for (int i = 0; i < shelves.Length && flag == false; i++)         // outer: goes through shelf 0, 1, 2, 3
                {
                    for (int j = 0; j < shelves[i].Length; j++)  // inner: goes through slots in shelf i
                    {
                        if (shelves[i][j] == null)
                        {
                            shelves[i][j] = isbn;
                            flag = true;
                            break;              // ← stops INNER loop only (stop scanning this shelf's slots)
                        }
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("\"Library shelves are full.\"");

                }
                Console.WriteLine($"Book added :{title}");
            }


        }
    }
}

