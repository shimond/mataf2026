
// external service, db, files
//using Microsoft.Data.SqlClient;


//SqlConnection con = new SqlConnection();
//con.Open();

//SqlCommand com;
//Console.WriteLine("BEFORE EXCUE:" + Thread.CurrentThread.ManagedThreadId); //881
//await com.ExecuteReaderAsync();
////com.ExecuteReader();
//Console.WriteLine("AFTER EXCUE:" + Thread.CurrentThread.ManagedThreadId );//881



//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7168/employees/search/ch");
//var content = await response.Content.ReadAsStringAsync();
//Console.WriteLine( content);

int reulst = await  GetTotalBytesFromUrl("http://mataf.co.il");
Console.WriteLine("Another thread");

static async Task<int> GetTotalBytesFromUrl(string url)
{
    // download url
    // save to file
    // return bytes count
    //Thread.Sleep(10000);
    await Task.Delay(10000);
    return Random.Shared.Next(10000, 20000);
}

////static Task<int> GetTotalBytesFromUrl(string url)
////{
////    return  Task.Factory.StartNew(() => {
////        // download url
////        // save to file
////        // return bytes count
////        Thread.Sleep(10000);
////        return Random.Shared.Next(10000, 20000);
////    });

//}