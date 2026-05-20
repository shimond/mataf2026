using UsersManagement.Models;

namespace UsersManagement.Contracts
{
    public interface IUserService
    {
        void Save();
        void Sync();
        void AddUser(UserInfo info);
        void DeleteUser(string idNumber);
        void UpdateUser(string idNumber, UserInfo info);
        UserInfo? FindUser(string idNumber);
        List<UserInfo> GetAllUsers();
    }
}
