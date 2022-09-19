using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap
{
    public class BookList
    {
        public Dictionary<int, Book> BooksListAll { get; set; } = new Dictionary<int, Book>();
        public Dictionary<string, HashSet<int>> BookTitles { get; set; } = new Dictionary<string, HashSet<int>>();
        public Dictionary<string, HashSet<int>> BookAuthors { get; set; } = new Dictionary<string, HashSet<int>>();
        public Dictionary<string, HashSet<int>> BookLanguages { get; set; } = new Dictionary<string, HashSet<int>>();

        public BookList()
        {
        }

        public void AddBookToBookList(string title, string author, string language)
        {
            if (!DoesExist(title, author, language))
            {
                var newBook = new Book(title, author, language);
                BooksListAll.Add(newBook.Id, newBook);
                if (BookTitles.ContainsKey(title))
                {
                    BookTitles[title].Add(newBook.Id);
                }
                else
                {
                    BookTitles.Add(newBook.Title, new HashSet<int> {newBook.Id});
                }

                if (BookAuthors.ContainsKey(author))
                {
                    BookAuthors[author].Add(newBook.Id);
                }
                else
                {
                    BookAuthors.Add(newBook.Author, new HashSet<int> { newBook.Id });
                }

                if (BookLanguages.ContainsKey(language))
                {
                    BookAuthors[language].Add(newBook.Id);
                }
                else
                {
                    BookAuthors.Add(newBook.Language, new HashSet<int> { newBook.Id });
                }
            }
        }

        public bool DoesExist(string title, string author, string language)
        {
            return GetBookId(title, author, language) == 0;
        }

        public int GetBookId(string title, string author, string language)
        {
            var key = BookTitles[title].Intersect(BookAuthors[author]).Intersect(BookLanguages[language]).FirstOrDefault();
            return key;
        }
    }
}