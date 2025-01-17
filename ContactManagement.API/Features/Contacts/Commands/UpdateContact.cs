using ContactManagement.API.Data;
using MediatR;

namespace ContactManagement.API.Features.Contacts.Commands;

public record UpdateContactCommand(Guid Id, DateTime BirthDate, string Email, string FirstName, string LastName, string PhoneNumber) : IRequest;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly ContactManagementDbContext _dbContext;

    public UpdateContactCommandHandler(ContactManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.FindAsync(request.Id);
        if (contact == null)
        {
            return;
        }

        contact.BirthDate = request.BirthDate;
        contact.Email = request.Email;
        contact.FirstName = request.FirstName;
        contact.LastName = request.LastName;
        contact.PhoneNumber = request.PhoneNumber;

        await _dbContext.SaveChangesAsync();
    }
}
