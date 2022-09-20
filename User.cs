namespace BookSwapping
{
    public class User
    {

        public string Name { get; set; }

        public static int UserIds = 0;

        // public DateTime Created { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public string PhoneNumber { get; set; }

        public HashSet<int> booksList = new HashSet<int>();
        public HashSet<int> locationsList = new HashSet<int>();

        public User(string name, string phoneNumber, int locationID)
        {
            Name = name;
            //Created = created;
            PhoneNumber = phoneNumber;
            locationsList.Add(locationID);
            UserId = UserIds++;
        }

        public void addBook(int bookID)
        {

        //   int bookID=  booksList.Add(Book.GetBookID( bookName, bookAuthor,  bookLanguage));
           booksList.Add(bookID);
        }

        public void removeBook(int bookID)
        {
            booksList.Remove(bookID);
        }

        public void updatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void addLocation(int locationID)
        {
            locationsList.Add(locationID);
        }

        public void removeLocation(int locationID)
        {
            locationsList.Remove(locationID);
        }

    }


}
