internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        

        builder.Services.AddControllersWithViews();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpClient();
        
        var app = builder.Build();
        
        
        

        app.UseAuthorization();

        app.MapControllers();
        app.MapControllerRoute(
            name: "default", 
            pattern: "{controller=home}/{action=Index}/{id?}"
            );
        app.Run();
    }
}