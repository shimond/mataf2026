using UsersManagement.Contracts;
using UsersManagement.Exceptions;
using UsersManagement.Models;

namespace UsersManagement.Services;

public class UserService : IUserService
{
    private readonly List<UserInfo> _users = new();
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void AddUser(UserInfo info)
    {
        var existingUser = FindUser(info.IdNumber);
        if (existingUser != null)
        {
            throw new DuplicateUserException($"A user with ID '{info.IdNumber}' already exists.")
            {
                DuplicateUserId = info.IdNumber
            };
        }
        _users.Add(info);
    }

    public UserInfo? FindUser(string idNumber)
    {
        var user = _users.FirstOrDefault(x => x.IdNumber == idNumber);
        return user;
    }

    public void DeleteUser(string idNumber)
    {
        var user = FindUser(idNumber);
        if (user != null)
        {
            _users.Remove(user);
        }
    }

    public void Save()
    {
        _userRepository.SaveUsers(_users);
    }   

    public void Sync()
    {
        var usersFromStorage = _userRepository.LoadUsers();
        _users.Clear();
        _users.AddRange(usersFromStorage);
    }

    public List<UserInfo> GetAllUsers()
    {
        return _users;
    }

    public void UpdateUser(string idNumber, UserInfo info)
    {
        var currentIndex = _users.FindIndex(x => x.IdNumber == idNumber);
        if (currentIndex != -1)
        {
            _users[currentIndex] = info;
        }
    }
}
