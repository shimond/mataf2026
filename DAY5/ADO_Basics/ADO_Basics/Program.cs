using ADO_Basics.Models;
using Microsoft.Data.SqlClient;


namespace ADO_Basics;

internal class Program
{
    static void Main(string[] args)
    {
        //InvokeSp();
        //ShowAllUsers();
        //UpdateDb();
        //GetOneValue();
    }

    private static void InvokeSp()
    {
        var connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Mataf;Integrated Security=True;Trust Server Certificate=True");

        var command = new SqlCommand("sp_getUserFullName", connection);
        command.Parameters.AddWithValue("@tz", "066385691");
        command.CommandType = System.Data.CommandType.StoredProcedure;
        connection.Open();
        string fullName = (string)command.ExecuteScalar();
        connection.Close();
        Console.WriteLine("Full Name: " + fullName);
    }

    private static void ShowAllUsers()
    {
        var users = GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.IdNumber}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}, Created At: {user.CreatedAt}");
        }
    }

    private static List<UserInfo> GetAllUsers()
    {
        List<UserInfo> users = new List<UserInfo>();
        SqlConnection connection =
                            new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Mataf;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand("Select IdNumber, FirstName, LastName, Email, CreatedAt from Users", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {

            var user = new UserInfo
            {
                IdNumber = reader.GetFieldValue<string>(0),
                FirstName = reader.GetFieldValue<string>(1),
                LastName = reader.GetFieldValue<string>(2),
                Email = reader.GetFieldValue<string>(3),
                CreatedAt = reader.GetFieldValue<DateTime>(4)
            };
            users.Add(user);
        }
        connection.Close();
        return users;
    }

    private static void UpdateDb()
    {
        Console.WriteLine("Enter the user ID to update:");
        string userIdToUpdate = Console.ReadLine();
        SqlConnection connection =
                    new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Mataf;Integrated Security=True;Trust Server Certificate=True");

        SqlCommand command = new SqlCommand("UPDATE Users SET FirstName = 'TEST' where IdNumber = @UserId", connection);
        command.Parameters.AddWithValue("@UserId", userIdToUpdate);
        connection.Open();
        var result = command.ExecuteNonQuery();
        Console.WriteLine("ROWS AFFECTED: " + result);
        connection.Close();
    }

    private static void GetOneValue()
    {
        SqlConnection connection =
                    new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Mataf;Integrated Security=True;Trust Server Certificate=True");

        SqlCommand command = new SqlCommand("Select Count(*) from Users", connection);
        connection.Open();
        var result = command.ExecuteScalar();
        Console.WriteLine(result);
        connection.Close();
    }
}
