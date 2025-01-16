namespace ContactManagement.API.Data.Models;

public class Contact
{
    public Guid Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
