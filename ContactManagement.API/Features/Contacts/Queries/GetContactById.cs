using Dapper;
using MediatR;
using System.Data;

namespace ContactManagement.API.Features.Contacts.Queries;

public record GetContactByIdQuery(Guid Id) : IRequest<GetContactByIdQueryResult?>;
public record GetContactByIdQueryResult(Guid Id, DateTime BirthDate, string Email, string FirstName, string LastName, string PhoneNumber);

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult?>
{
    private readonly IDbConnection _connection;

    public GetContactByIdQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<GetContactByIdQueryResult?> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        return await _connection.QuerySingleOrDefaultAsync<GetContactByIdQueryResult>(CreateSql(), new { request.Id });

        string CreateSql()
        {
            return @"SELECT c.Id,
                            c.BirthDate,
                            c.Email,
                            c.FirstName,
                            c.LastName,
                            c.PhoneNumber
                       FROM dbo.Contact c
                      WHERE c.Id = @Id";
        }
    }
}
