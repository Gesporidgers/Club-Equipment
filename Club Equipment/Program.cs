using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Club_Equipment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddDbContext<LD_context>(options =>options.UseSqlite("Data Source = LD.db"));
			builder.Services.AddEndpointsApiExplorer();
			var app = builder.Build();
			app.UseStaticFiles();
			app.MapControllers();

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
