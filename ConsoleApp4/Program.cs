using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            using (var booksPages = new DataClasses1DataContext())
            {
                var query = booksPages.Books.Where(book => book.Page >= 100);

                foreach (var book in query)
                {
                    Console.WriteLine($"Book: {book.Name}, Pages: {book.Page}");
                }
            }
            //2
            using (var booksName = new DataClasses1DataContext())
            {
                var query = booksName.Books.Where(x => x.Name.StartsWith("A"));

                foreach (var book in query)
                {
                    Console.WriteLine($"Book: {book.Name}");
                }
            }
            //3
            using (var books = new DataClasses1DataContext())
            {
                var booksBy = from book in books.Books
                              where book.Author.Name == "David" && book.Author.Surname == "Brown"
                              select book;

                foreach (var book in booksBy)
                {
                    Console.WriteLine($"Book: {book.Name}");
                }
            }
            //4
            using (var books = new DataClasses1DataContext())
            {
                var query = from author in books.Authors
                            where author.Country.Name == "Canada"
                            orderby author.Name, author.Surname
                            select author;

                foreach (var writer in query)
                {
                    Console.WriteLine($"Author: {writer.Name} {writer.Surname}");
                }
            }
            //5
            using (var shortBook = new DataClasses1DataContext())
            {
                var query = shortBook.Books.Where(book => book.Name.Length > 10);

                foreach (var book in query)
                {
                    Console.WriteLine($"Book: {book.Name}");
                }
            }
            //6
            using (var data = new DataClasses1DataContext())
            {
                string country = "Canada";

                Book bookPages = data.Authors.Where(x => x.Country.Name == country)
                                             .SelectMany(x => x.Books)
                                             .OrderByDescending(x => x.Page)
                                             .FirstOrDefault();

                if (bookPages != null)
                {
                    Console.WriteLine($"Book with the maximum pages from {country}: {bookPages.Name}, Pages: {bookPages.Page}");
                }
                else
                {
                    Console.WriteLine($"No books found from {country}");
                }
            }
            //7
            using (var data = new DataClasses1DataContext())
            {
                var author = data.Authors.OrderBy(x => x.Books.Count).FirstOrDefault();

                if (author != null)
                {
                    Console.WriteLine($"Author with the fewest books: {author.Name} {author.Surname}");
                }
                else
                {
                    Console.WriteLine("No authors found");
                }
            }
            //8
            using (var data = new DataClasses1DataContext())
            {
                Country country = data.Countries.OrderBy(x => x.Authors.Count).First();

                if (country != null)
                {
                    Console.WriteLine($"Country with the most authors: {country.Name}");
                }
                else
                {
                    Console.WriteLine("No countries found");
                }
            }
        }
    }
}
