// See https://aka.ms/new-console-template for more information

using BookSwapping;

Console.WriteLine("Hello, World!");

Location l1 = new Location("Microsoft Haifa", Location.LocationType.Work, "my perfect work place");



var user1 = UserList.AddUserToUserList("Shira", "0552", l1.LocationId);
var user2 = UserList.AddUserToUserList("Sapir", "0548", l1.LocationId);
var user3 = UserList.AddUserToUserList("Masha", "0541", l1.LocationId);
var user4 = UserList.AddUserToUserList("Vladik", "0547", l1.LocationId);



var book1 = BookList.AddBookToBookList("Harry Potter", "J.K.Rowling", "English");
var book2 = BookList.AddBookToBookList("Harry Potter 2", "J.K.Rowling", "English");
var book3 = BookList.AddBookToBookList("Harry Potter 3", "J.K.Rowling", "English");
var book4 = BookList.AddBookToBookList("Harry Potter 4", "J.K.Rowling", "English");



UserList.GetUserByUserKey(user1)?.addBook(book1);
UserList.GetUserByUserKey(user2)?.addBook(book2);
UserList.GetUserByUserKey(user3)?.addBook(book3);
UserList.GetUserByUserKey(user4)?.addBook(book4);



var searchResult = BookList.SearchBooks("", "J.K.Rowling");





Console.WriteLine("finish");

