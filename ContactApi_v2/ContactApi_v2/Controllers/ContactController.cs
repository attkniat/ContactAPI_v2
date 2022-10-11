using ContactEngine.ContactModel;
using ContactEngine.ContactsInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactApi_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public List<Contact> GetAllContact() => _contactRepository.GetContactsAsync().Result;
    }
}
