using Microsoft.EntityFrameworkCore;

namespace MyInventory.Data
{
    public static class ContainerMigrations
    {
        public static void ApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("Applying Migrations...");
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
            }
        }
    }
}
