using ContactManagement.API.Data.Models;
using ContactManagement.API.Data.Models.Configs;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.API.Data;

public class ContactManagementDbContext : DbContext
{
    public ContactManagementDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactConfig).Assembly);

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(2000, 1, 1),
                Email = "johndoe@example.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1990, 12, 31),
                Email = "janesmith@example.com",
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "5559874567"
            });
    }
}
