using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using todoApi;
using todoApi.Data;

namespace TodoApi.Tests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        private SqliteConnection _connection;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the existing DbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TodoContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add in-memory SQLite database
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                services.AddDbContext<TodoContext>(options =>
                {
                    options.UseSqlite(_connection);
                });

                // Build the service provider
                var sp = services.BuildServiceProvider();

                // Create and open the database
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
                db.Database.EnsureCreated();
                // Optional: Seed test data here if needed
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}