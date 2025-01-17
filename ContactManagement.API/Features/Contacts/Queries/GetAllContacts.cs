using Dapper;
using MediatR;
using System.Data;

namespace ContactManagement.API.Features.Contacts.Queries;

public record GetAllContactsQuery : IRequest<IEnumerable<GetAllContactsQueryResult>>;
public record GetAllContactsQueryResult(Guid Id, DateTime BirthDate, string Email, string FirstName, string LastName, string PhoneNumber);

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<GetAllContactsQueryResult>>
{
    private readonly IDbConnection _connection;

    public GetAllContactsQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<GetAllContactsQueryResult>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        return await _connection.QueryAsync<GetAllContactsQueryResult>(CreateSql());

        string CreateSql()
        {
            return @"SELECT c.Id,
                            c.BirthDate,
                            c.Email,
                            c.FirstName,
                            c.LastName,
                            c.PhoneNumber
                       FROM dbo.Contact c";
        }
    }
}
