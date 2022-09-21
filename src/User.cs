namespace BookSwapping
{
    public class User
    {
        public static int Counter = 1;
        public HashSet<int> booksList = new();
        public HashSet<int> locationsList = new();

        public string Name { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }


        public User(string name, string phoneNumber, int locationId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            locationsList.Add(locationId);
            UserId = Counter++;
        }

        public void addBook(int bookID)
        {
            booksList.Add(bookID);
        }

        public void emoveBook(int bookID)
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
