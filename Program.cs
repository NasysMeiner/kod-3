using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            BookShelf bookShelf = new BookShelf();

            Book book1 = new Book( "Капитанская дочка", "Пушкин", 1836 );
            Book book2 = new Book( "Дубровский", "Пушкин", 1841 );
            Book book3 = new Book( "Паруса", "Лермонтов", 1841 );

            bookShelf.AddBook(book1);
            bookShelf.AddBook(book2);
            bookShelf.AddBook(book3);

            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню:\n1 - добавить книгу.\n2 - убрать книгу.\n3 - показать все книги.\n4 - показать книги по указанному значению.\n5 - выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        bookShelf.AddUserBook();
                        break;
                    case "2":
                        bookShelf.DeleteBook();
                        break;
                    case "3":
                        bookShelf.ShowAllInfoBook();
                        break;
                    case "4":
                        bookShelf.SearchBooks();
                        break;
                    case "5":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class BookShelf
    {
        private List<Book> _books = new List<Book>();

        public void DeleteBook()
        {
            string userInput;
            int bookIndex;

            Console.WriteLine("Введите ID");
            userInput = Console.ReadLine();
            bookIndex = SearchIdBook(userInput);

            if (bookIndex > 0)
            {
                _books.RemoveAt(bookIndex);
                Console.WriteLine("Книга удалена.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddUserBook()
        {
            string userInput;
            string author;
            string name;
            int length = _books.Count;

            Console.Write("Введите название:");
            name = Console.ReadLine();

            Console.Write("Введите автора:");
            author = Console.ReadLine();

            Console.Write("Введите год написания:");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result3))
            {
                Book book = new Book(name, author, result3);
                AddBook(book);
                Console.WriteLine("Книга добавлена.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ShowAllInfoBook()
        {
            Console.WriteLine();

            foreach (Book book in _books)
            {
                Console.WriteLine($"{book.Author}: {book.Name}. Год написания: {book.YearOfIssue}. ID: {book.Id}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void SearchBooks()
        {
            string userInput;

            Console.Clear();
            Console.WriteLine("\nВыберите параметр поиска:\n1 - по автору.\n2 - по названию.\n3 - по году написания.\n");
            userInput= Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowBookToAuthor();
                    break;
                case "2":
                    SearchIdBookToName();
                    break;
                case "3":
                    ShowBookToYears();
                    break;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        private int SearchIdBook(string userInput)
        {
            int intermediateId = 0;
            int bookId = -1;

            if (int.TryParse(userInput, out int result))
            {
                foreach (Book book in _books)
                {
                    if (book.Id == result)
                    {
                        bookId = intermediateId;
                    }

                    intermediateId++;
                }

                return bookId;
            }
            else
            {
                Console.WriteLine("Такой книги нет.");
                Console.ReadLine();
                Console.Clear();
                return -1;
            }
        }

        private void ShowInfoBook(Book book)
        {
            Console.WriteLine($"{book.Author}: {book.Name}. Год написания: {book.YearOfIssue}. ID: {book.Id}");
        }

        private void ShowBookToAuthor()
        {
            string userInput;
            bool availabilityBook = false;

            Console.Write("Введите автора книги:");
            userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author == userInput)
                {
                    ShowInfoBook(book);
                    availabilityBook = true;
                }
            }

            if (availabilityBook == false)
            {
                Console.WriteLine("Такой книги нет.");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void ShowBookToYears()
        {
            string userInput;

            Console.Write("Введите год написания книги:");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                foreach (Book book in _books)
                {
                    if (book.YearOfIssue == result)
                    {
                        ShowInfoBook(book);
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
                Console.ReadLine();
                Console.Clear();
            }         
        }

        private int SearchIdBookToName()
        {
            string userInput;
            int booksId = 0;
            int bookId = 0;

            Console.Write("Введите название книги:");
            userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Name == userInput)
                {
                    ShowInfoBook(book);
                    bookId = booksId;
                }

                booksId++;
            }

            if (bookId > 0)
            {
                Console.ReadLine();
                Console.Clear();
                return bookId;
            }
            else
            {
                Console.WriteLine("Такой книги нет.");
                Console.ReadLine();
                Console.Clear();
                return -1;
            }
        }
    }

    class Book
    {
        private static _ids = 10;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearOfIssue { get; private set; }

        public Book (string name, string aurhor, int yearOfIssue)
        {
            Id = ++Ids;
            Name = name;
            Author = aurhor;
            YearOfIssue = yearOfIssue;
        }
    }
}
