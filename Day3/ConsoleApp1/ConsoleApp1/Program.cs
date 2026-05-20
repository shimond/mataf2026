using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

var client = new HttpClient();

var body = new
{
    key = "hYJZOir1i",
    user = "0584333322",
    pass = "36530225",
    sender = "KEYZ",
    recipient = "0546490218",
    msg = "דוגמא api"
};

var json = JsonConvert.SerializeObject(body);
var content = new StringContent(json, Encoding.UTF8, "application/json");

var response = await client.PostAsync("https://api.sms4free.co.il/ApiSMS/v2/SendSMS", content);
var result = await response.Content.ReadAsStringAsync();
Console.WriteLine(result);