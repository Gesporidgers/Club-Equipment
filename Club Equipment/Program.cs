namespace Club_Equipment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();
			app.UseStaticFiles();

			app.Run(async (context) =>
			{
				var path = context.Request.Path;
				string fullpth = "html/" + path + ".html";
				context.Response.ContentType = "text/html";
				if (path == "/")
				{
					await context.Response.SendFileAsync("html/index.html");
				}
				else if (Path.Exists(fullpth))
				{
					await context.Response.SendFileAsync(fullpth);
				}
				
				
			});

			app.Run();

		}
	}
}
