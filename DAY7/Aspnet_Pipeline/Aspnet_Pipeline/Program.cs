var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.UseStaticFiles();

app.Use(async (context, next) =>
{
	try
	{
        //context.Request.Method == "GET"
        await context.Response.WriteAsync(" MY Middleware A 1 "); // 1
        await next();
        await context.Response.WriteAsync(" MY Middleware A 2 "); //4
    }
	catch (Exception ex)
	{
		throw;
	}
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync(" MY Middleware B 1 "); //2
    await next();
    await context.Response.WriteAsync(" MY Middleware B 2 "); // 3
});

app.Run();

