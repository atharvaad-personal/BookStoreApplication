using System.IO.Pipes;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>
            {
                new BookModel()
                {
                    Id =  1,
                    Title = "MVC",
                    Author = "Atharva"
                },
                new BookModel()
                {
                    Id =  2,
                    Title = "Web API",
                    Author = "Atharva"
                },
                new BookModel()
                {
                    Id =  3,
                    Title = "EF Core",
                    Author = "Nitish"
                },
                new BookModel()
                {
                    Id =  4,
                    Title = "ReactJS",
                    Author = "WebGentle"
                },
                new BookModel()
                {
                    Id =  5,
                    Title = "AWS",
                    Author = "WebGentle"
                }
            };
        }
    }
}
