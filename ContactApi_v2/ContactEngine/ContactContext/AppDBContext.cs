using ContactEngine.ContactModel;
using Microsoft.EntityFrameworkCore;

namespace ContactEngine.ContactData
{
    public class AppDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=C:/Users/nathan.oliveira/Desktop/ContactAPI_v2/ContactApi_v2/ContactEngine/ContactData/AppDB.db");

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
