
namespace BookSwap
{
    public class Book
    {
        private static int s_counter = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }

        public Book(string title, string author, string language)
        {
            Title = title;
            Author = author;
            Language = language;
            Id = s_counter++;
        }

        public bool Equals(Book other)
        {
            return Title.Equals(other.Title) && Author.Equals(other.Author)
                && Language.Equals(other.Language);
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Language: {Language}";
        }
    }
}