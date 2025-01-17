using ContactManagement.API.Data;
using MediatR;

namespace ContactManagement.API.Features.Contacts.Commands;

public record DeleteContactCommand(Guid Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly ContactManagementDbContext _dbContext;

    public DeleteContactCommandHandler(ContactManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.FindAsync(request.Id);
        if (contact == null)
        {
            return;
        }

        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
    }
}
