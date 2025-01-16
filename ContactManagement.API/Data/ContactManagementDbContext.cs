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
                Id = Guid.Parse("a77bdc67-e4d3-4928-a5bd-f51a95a6b878"),
                BirthDate = DateTime.Parse("01/01/2000"),
                Email = "johndoe@example.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            },
            new Contact
            {
                Id = Guid.Parse("71eb7f9b-9d1c-4238-8f88-853d10673e4c"),
                BirthDate = DateTime.Parse("12/31/1990"),
                Email = "janesmith@example.com",
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "5559874567"
            });
    }
}
