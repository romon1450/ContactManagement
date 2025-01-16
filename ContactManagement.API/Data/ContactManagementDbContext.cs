using ContactManagement.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.API.Data;

public class ContactManagementDbContext : DbContext
{
    public ContactManagementDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Contact> Contacts { get; set; }
}
