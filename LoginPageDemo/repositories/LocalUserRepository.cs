using LoginPageDemo.entities;

namespace LoginPageDemo.repositories;

public class LocalUserRepository : IUserRepository
{
    private readonly List<User> users = new()
{
    new User
    {
        Id = 1,
        Name = "frank",
        UserName = "obaank",
        Password = "password",
        ConfirmPassword = "password"
    }
};

    //get all users
    public IEnumerable<User> GetAllUsers()
    {
        return users;
    }
    //create user
    public void CreateUser(User user)
    {
        user.Id = users.Max(user => user.Id) + 1;
        users.Add(user);
    }
    //get user by username
    public User? GetUser(string username)
    {
        return users.Find(users => users.UserName == username);
    }
}