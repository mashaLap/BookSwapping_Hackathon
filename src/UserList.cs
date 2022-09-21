namespace BookSwapping
{
    public class UserList
    {
        public static Dictionary<int, User> UsersListAll { get; set; } = new();


        public static int AddUserToUserList(string name, string phoneNumber, int locationID)
        {
            var newUser = new User(name, phoneNumber, locationID);
            UsersListAll.Add(newUser.UserId, newUser);
            return newUser.UserId;
        }

        public static User? GetUserByUserKey(int userId)
        {
            if (UsersListAll.TryGetValue(userId, out var user))
            {
                return user;
            }
            return null;
        }
    }
}
