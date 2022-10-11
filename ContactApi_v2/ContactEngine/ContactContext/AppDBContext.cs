using ContactEngine.ContactModel;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace ContactEngine.ContactData
{
    public class AppDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            var fullPath = Path.GetFullPath(Path.Combine(dirPath, "ContactData/AppDB.db"));

            dbContextOptionsBuilder.UseSqlite($"Data Source={fullPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Contact[] contacts = new Contact[5];

            for (int i = 1; i <= 5; i++)
            {
                contacts[i - 1] = new Contact
                {
                    ContactId = i,
                    Email = $"DavidSmith{i}@gmail.com",
                    Name = $"David Smith 0{i}",
                    Phone = $"{i}234567890"
                };
            }
            modelBuilder.Entity<Contact>().HasData(contacts);
        }
    }
}
