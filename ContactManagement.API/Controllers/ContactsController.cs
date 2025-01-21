using ContactManagement.API.Features.Contacts.Commands;
using ContactManagement.API.Features.Contacts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllContactsQueryResult>>> GetAllContacts()
    {
        var contacts = await _mediator.Send(new GetAllContactsQuery());
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetContactByIdQueryResult>> GetContactById(Guid id)
    {
        var contact = await _mediator.Send(new GetContactByIdQuery(id));
        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(AddContactCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(Guid id, UpdateContactCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        await _mediator.Send(new DeleteContactCommand(id));
        return NoContent();
    }
}
