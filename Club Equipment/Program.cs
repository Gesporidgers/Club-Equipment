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
				context.Response.ContentType = "text/html";
				await context.Response.SendFileAsync("html/index.html");
			});

			app.Run();

		}
	}
}
