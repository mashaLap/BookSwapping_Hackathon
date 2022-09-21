using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwapping
{
    public class UserBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }


        public UserBook(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }

    public static class BookList
    {
        public static Dictionary<int, Book> BooksListAll { get; set; } = new Dictionary<int, Book>();

        public static Dictionary<string, HashSet<int>> BookTitles { get; set; } = new Dictionary<string, HashSet<int>>();

        public static Dictionary<string, HashSet<int>> BookAuthors { get; set; } = new Dictionary<string, HashSet<int>>();

        public static Dictionary<string, HashSet<int>> BookLanguages { get; set; } = new Dictionary<string, HashSet<int>>();


        public static string Print()
        {
            var str = string.Empty;
            foreach (var value in BooksListAll.Values)
            {
                str += value.ToString();
                str += "\n";
            }
            return str;
        }

        public static int AddBookToBookList(string title, string author, string language)
        {
            var bookId = GetBookId(title, author, language);
            if (bookId == 0)
            {
                var newBook = new Book(title, author, language);
                bookId = newBook.Id;
                BooksListAll.Add(newBook.Id, newBook);

                if (BookTitles.ContainsKey(title))
                {
                    BookTitles[title].Add(newBook.Id);
                }
                else
                {
                    BookTitles.Add(newBook.Title, new HashSet<int> { newBook.Id });
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
                    BookLanguages[language].Add(newBook.Id);
                }
                else
                {
                    BookLanguages.Add(newBook.Language, new HashSet<int> { newBook.Id });
                }
            }
            return bookId;
        }

        public static bool DoesExist(string title, string author, string language)
        {
            return GetBookId(title, author, language) == 0;
        }

        public static int GetBookId(string title, string author, string language)
        {
            if (BookTitles.ContainsKey(title) && BookAuthors.ContainsKey(author) && BookLanguages.ContainsKey(language))
            {
                return BookTitles[title].Intersect(BookAuthors[author]).Intersect(BookLanguages[language]).FirstOrDefault();
            }
            return 0; 
       }

        public static List<UserBook> SearchBooks(string title = "", string author = "", string language = "", int location = -1)
        {
            IEnumerable<int> keys; if (title != "" && author != "" && language != "") { keys = BookTitles[title].Intersect(BookAuthors[author]).Intersect(BookLanguages[language]); } else if (title != "" && author != "") { keys = BookTitles[title].Intersect(BookAuthors[author]); } else if (title != "" && language != "") { keys = BookTitles[title].Intersect(BookLanguages[language]); } else if (author != "" && language != "") { keys = BookAuthors[author].Intersect(BookLanguages[language]); } else if (title != "") { keys = BookTitles[title]; } else if (author != "") { keys = BookAuthors[author]; } else { keys = BookLanguages[language]; }

            var userKeyList = new List<UserBook>();

            foreach (var user in location < 0 ? UserList.UsersListAll : UserList.UsersListAll.Where(x => x.Value.locationsList.Contains(location))) { foreach (var key in keys) { if (user.Value.booksList.Contains(key)) { userKeyList.Add(new UserBook(user.Value.UserId, key)); } } }
            return userKeyList;
        }
    }


}
