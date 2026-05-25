using FirstWebApi;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();


app.MapPost("addNewPerson", (Person p) => {
    return p;
});


app.MapGet("countDuplicates", (string[] name) =>
{
    return name.Length;
});


app.MapGet("add/{p1}/{p2}", (int p2, int p1  ) => {
    return p1 + p2;
});


app.MapGet("random", (int min = 0, int max = 1000) =>
{
    return Random.Shared.Next(min, max);
}); 
//dir is required
app.MapGet("GetFiles/{dir}", (string dir, int? len  = null) => {
    var path = "c:\\" + dir;
    if (len is null)
    {
        return Directory.GetFiles(path);
    }
    return Directory.GetFiles(path).Take(len.Value).ToArray();
});

//foramt is optional
app.MapGet("GetTime", (string? format = "dd/MM/yyyy", int? addDays = null) =>
{
    if (addDays is null)
    {
        return DateTime.Now.ToString(format);
    }
    return DateTime.Now.AddDays(addDays.Value).ToString(format);
});


app.Run();

