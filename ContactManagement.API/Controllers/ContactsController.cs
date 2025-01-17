using ContactManagement.API.Data;
using ContactManagement.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactManagementDbContext _context;

        public ContactsController(ContactManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContactsAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactByIdAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContactAsync(Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactAsync(Guid id, Contact updatedContact)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.BirthDate = updatedContact.BirthDate;
            contact.Email = updatedContact.Email;
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.PhoneNumber = updatedContact.PhoneNumber;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
