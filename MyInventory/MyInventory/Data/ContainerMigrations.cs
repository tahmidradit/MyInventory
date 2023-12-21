using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace MyInventory.Data
{
    public static class ContainerMigrations
    {
        public static void ApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("Applying Migrations...");
                //serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                var services = serviceScope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
