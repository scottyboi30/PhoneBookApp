using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneAppTest.Data;
using PhoneAppTest.Models;
using PhoneAppTest.Services;

namespace PhoneAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IContactsService _contactsService;
        
        public ContactsController(IContactsRepository contactsRepository, IContactsService contactsService)
        {
            _contactsRepository = contactsRepository;
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts([FromQuery]string searchTerm)
        {
            return Ok(await _contactsService.GetContactsAsync(searchTerm));
        }

        [HttpPost]
        public async Task<ActionResult> SaveContacts(List<Contact> contacts)
        {
            await _contactsRepository.SaveContactsAsync(contacts);
            return NoContent();
        }
    }
}
