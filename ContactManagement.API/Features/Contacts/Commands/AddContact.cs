using ContactManagement.API.Data;
using ContactManagement.API.Data.Models;
using MediatR;

namespace ContactManagement.API.Features.Contacts.Commands;

public record AddContactCommand(DateTime BirthDate, string Email, string FirstName, string LastName, string PhoneNumber) : IRequest;

public class AddContactCommandHandler : IRequestHandler<AddContactCommand>
{
    private readonly ContactManagementDbContext _dbContext;

    public AddContactCommandHandler(ContactManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddContactCommand request, CancellationToken cancellationToken)
    {
        var newContact = new Contact
        {
            Id = Guid.NewGuid(),
            BirthDate = request.BirthDate,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        };

        _dbContext.Contacts.Add(newContact);
        await _dbContext.SaveChangesAsync();
    }
}
