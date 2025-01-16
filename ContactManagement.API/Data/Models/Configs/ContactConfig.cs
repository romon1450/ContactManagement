using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.API.Data.Models.Configs;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");
        builder.Property(t => t.Email).HasMaxLength(200);
        builder.Property(t => t.FirstName).HasMaxLength(200);
        builder.Property(t => t.LastName).HasMaxLength(200);
        builder.Property(t => t.PhoneNumber).HasMaxLength(50);
    }
}
