using UsersManagement.Contracts;
using UsersManagement.Exceptions;
using UsersManagement.Models;
using UsersManagement.Services;

namespace UsersManagement;

public class Program
{
    private static readonly IUserRepository _userRepository = new JsonUserRepository();
    private static readonly IUserService _userService = new UserService(_userRepository);

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Users Management System");
        Console.WriteLine("===================================\n");

        // Load existing users from storage
        _userService.Sync();
        Console.WriteLine("Users loaded from storage.\n");

        bool running = true;
        while (running)
        {
            try
            {
                int choice = DisplayMenu();

                switch (choice)
                {
                    case 1:
                        AddUserMenu();
                        break;
                    case 2:
                        RemoveUserMenu();
                        break;
                    case 3:
                        UpdateUserMenu();
                        break;
                    case 4:
                        DisplayAllUsersMenu();
                        break;
                    case 5:
                        SaveMenu();
                        break;
                    case 6:
                        ExitApplication();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
                Console.WriteLine("Please try again.\n");
            }
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("--- Main Menu ---");
        Console.WriteLine("1. Add User");
        Console.WriteLine("2. Remove User");
        Console.WriteLine("3. Update User");
        Console.WriteLine("4. Display All Users");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Exit");
        Console.Write("\nEnter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        return 0; // Invalid input returns 0
    }

    static void AddUserMenu()
    {
        Console.WriteLine("\n--- Add New User ---");

        Console.Write("Enter ID Number: ");
        string idNumber = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? string.Empty;

        var newUser = new UserInfo
        {
            IdNumber = idNumber,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            CreatedAt = DateTime.Now
        };

        try
        {
            _userService.AddUser(newUser);
            Console.WriteLine($"\nUser '{firstName} {lastName}' added successfully!\n");
        }
        catch (DuplicateUserException ex)
        {
            Console.WriteLine($"\nError: Cannot add user with ID '{ex.DuplicateUserId}' as it already exists.\n");
        }
    }

    static void RemoveUserMenu()
    {
        Console.WriteLine("\n--- Remove User ---");

        Console.Write("Enter ID Number of user to remove: ");
        string idNumber = Console.ReadLine() ?? string.Empty;

        var user = _userService.FindUser(idNumber);
        if (user != null)
        {
            _userService.DeleteUser(idNumber);
            Console.WriteLine($"\nUser '{user.FirstName} {user.LastName}' removed successfully!\n");
        }
        else
        {
            Console.WriteLine($"\nUser with ID '{idNumber}' not found.\n");
        }
    }

    static void UpdateUserMenu()
    {
        Console.WriteLine("\n--- Update User ---");

        Console.Write("Enter ID Number of user to update: ");
        string idNumber = Console.ReadLine() ?? string.Empty;

        var existingUser = _userService.FindUser(idNumber);
        if (existingUser != null)
        {
            Console.WriteLine($"\nCurrent User: {existingUser.FirstName} {existingUser.LastName} ({existingUser.Email})");
            Console.WriteLine("\nEnter new details:");

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            var updatedUser = new UserInfo
            {
                IdNumber = idNumber,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CreatedAt = existingUser.CreatedAt // Keep original creation date
            };

            _userService.UpdateUser(idNumber, updatedUser);
            Console.WriteLine($"\nUser '{firstName} {lastName}' updated successfully!\n");
        }
        else
        {
            Console.WriteLine($"\nUser with ID '{idNumber}' not found.\n");
        }
    }

    static void DisplayAllUsersMenu()
    {
        Console.WriteLine("\n--- All Users ---");

        var users = _userService.GetAllUsers();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found.\n");
            return;
        }

        Console.WriteLine($"\nTotal Users: {users.Count}\n");
        Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-30} {4,-20}", 
            "ID Number", "First Name", "Last Name", "Email", "Created At");
        Console.WriteLine(new string('-', 105));

        foreach (var user in users)
        {
            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-30} {4,-20}",
                user.IdNumber,
                user.FirstName,
                user.LastName,
                user.Email,
                user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        Console.WriteLine();
    }

    static void SaveMenu()
    {
        Console.WriteLine("\n--- Save ---");
        _userService.Save();
        Console.WriteLine("All users saved to storage successfully!\n");
    }

    static void ExitApplication()
    {
        Console.WriteLine("\n--- Exit ---");
        _userService.Save();
        Console.WriteLine("All users saved to storage.");
        Console.WriteLine("Thank you for using Users Management System. Goodbye!\n");
    }
}

