using UsersManagement.Models;

namespace UsersManagement.Contracts;

public interface IUserRepository
{
    void SaveUsers(List<UserInfo> users);
    List<UserInfo> LoadUsers();

}
