using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._02._23_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList bookList = new BookList();
            Book book = new Book("gUGA");
            Book book2 = new Book("bgb");
            Book book3 = new Book("fwef");
            Book book4 = new Book("fwfwfewf");
            bookList.Add(book);
            bookList.Add(book2);
            bookList.Add(book3);
            BookList bookList1 = new BookList();
            bookList1 = bookList + book4;

        }
    }
}
