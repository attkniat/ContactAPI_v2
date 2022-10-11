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
        [Route("get-all-contact")]
        public List<Contact> GetAllContact() => _contactRepository.GetContactsAsync().Result;

        [HttpGet]
        [Route("get-contact-by-id")]
        public Contact GetContactById(int contactId) => _contactRepository.GetContactByIdAsync(contactId).Result;
        
        [HttpPost]
        [Route("create-contact")]
        public bool CreateContact(Contact contactToCreate) => _contactRepository.CreateContactAsync(contactToCreate).Result;

        [HttpPut]
        [Route("update-contact")]
        public bool UpdateContact(Contact contactToUpdate) => _contactRepository.UpdateContactAsync(contactToUpdate).Result;

        [HttpDelete]
        [Route("delete-contact")]
        public bool DeleteContact(int contactId) => _contactRepository.DeletePostAsync(contactId).Result;
    }
}
