using LoginPageDemo.entities;

namespace LoginPageDemo.repositories;

public interface IUserRepository
{
    void CreateUser(User user);
    IEnumerable<User> GetAllUsers();
    User? GetUser(string username);
}
