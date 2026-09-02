using System;
using System.Collections.Generic;
using System.Text;


namespace OOP_Classes
{
    public class Book
    {
        public string ISBN;
        public string Title;
        public string Author;
        public BookStatus Status;

    
    public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Status = BookStatus.Available;
        }


        
    
    }
}       
