HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7168/employees/search/ch");
var content = await response.Content.ReadAsStringAsync();
Console.WriteLine( content);