var numbers = new List<int> { 1, 2, 3, 4, 5 };

var query = numbers.Where(n => n > 2);

numbers.Add(6);

foreach (var n in query)
{
    Console.WriteLine(n);
}

////////////////////////////////////////////////////
try
{
    DoWork();
}
catch (Exception)
{
    throw;
}
Console.WriteLine("WOW");
async void DoWork()
{
    await Task.Delay(100);
    throw new Exception("Boom");
}

/////////////////////////////////////////////////
var tasks = new List<Task>();

for (int i = 0; i < 5; i++)
{
    var t = Task.Run(async () =>
    {
        var c = i;
        Console.WriteLine("START WOKRING ON " + c);
        await Task.Delay(100);
        Console.WriteLine("COMPLETE WOKRING ON " + c);

    });
    tasks.Add(t);
}

await Task.WhenAll(tasks);
/////////////////////////////////////////////////


public class SqlServerDatabase
{
    public void Save(Order order)
    {
        Console.WriteLine("Saving order to SQL Server");
    }
}

public class EmailSender
{
    public void Send(string to, string message)
    {
        Console.WriteLine("Sending email");
    }
}

public class Order
{
    public decimal Amount { get; set; }
}
//////////////////////////////////////////////////////
public class OrderService
{
    private readonly SqlServerDatabase _database = new SqlServerDatabase();
    private readonly EmailSender _emailSender = new EmailSender();

    public void PlaceOrder(Order order)
    {
        if (order.Amount <= 0)
            throw new Exception("Invalid order");

        _database.Save(order);

        _emailSender.Send("customer@example.com", "Order placed");
    }
}

/////////////////////////////////////////////////
