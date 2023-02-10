using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._02._23_HW
{
    internal class Book
    {
        public string Name { get; set; }
        public Book() { }
        public Book(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    internal class BookList
    {
        static private int count = 0;
        private Book[] list = new Book[count];

        public BookList() { }
        public BookList(Book[] books)
        {
            this.list = books;
        }
        
        public void Add(Book a)
        {
            count++;
            BookList buf = new BookList();
            for(int i = 0; i < count - 1; i++)
                buf.list[i] = this.list[i];
            buf.list[count - 1] = a;
            this.list = buf.list;
        }
        public void Delete(Book a)
        {
            int index = -1;
            for(int i =0; i < count-1; i++)
                if (list[i].Name == a.Name)
                    index = i;
            if (index == -1)
            {
                Console.WriteLine("Такой книги нет");
                return;
            }
            count--;
            BookList buf = new BookList();
            for (int i = 0, j = 0; i <= count; i++)
            {
                if(i != index)
                {
                    buf.list[j] = list[i];
                    j++;
                }
            }
            this.list = buf.list;
        }
        public override string ToString()
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine($"{i+1}. {list[i]}");
            return "";
        }

        public static BookList operator+(BookList a, Book b)
        {
            count++;
            BookList buf = new BookList();
            for (int i = 0; i < count - 1; i++)
                buf.list[i] = a.list[i];
            buf.list[count - 1] = b;
            return buf;
        }
        public static BookList operator-(BookList a, Book b)
        {
            int index = -1;
            for (int i = 0; i < count - 1; i++)
                if (a.list[i].Name == b.Name)
                    index = i;
            if (index == -1)
            {
                Console.WriteLine("Такой книги нет");
                return a;
            }
            count--;
            BookList buf = new BookList();
            for (int i = 0, j = 0; i < count ; i++)
            {
                if (i != index)
                {
                    buf.list[j] = a.list[i];
                    j++;
                }
            }
            return buf;
        }
        public static bool operator==(BookList a, Book b)
        {
            int index = -1;
            for (int i = 0; i < count - 1; i++)
                if (a.list[i].Name == b.Name)
                    index = i;
            if (index == -1)
                return false;
            else
                return true;
        }
        public static bool operator !=(BookList a, Book b)
        {
            return !(a == b);
        }

        public void Search(string a)
        {
            int index = -1;
            for (int i = 0; i < count - 1; i++)
                if (list[i].Name == a)
                    index = i;
            if (index == -1)
                Console.WriteLine("Такой книги нет");
            else
                Console.WriteLine($"Книга в списке есть под номером: {index +1}");
        }


        public string this[int index]
        {
            get
            {
                if (index >= list.Length|| index < 0)
                    throw new Exception("Некорректный индекс");
                else
                    return list[index].Name;
            }
            set
            {
                if (index >= list.Length || index < 0)
                    throw new Exception("Некорректный индекс");
                else
                    list[index].Name = value;
            }
        }

    }
}
