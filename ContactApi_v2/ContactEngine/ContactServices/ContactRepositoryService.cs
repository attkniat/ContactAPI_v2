using ContactEngine.ContactModel;
using ContactEngine.ContactsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEngine.ContactServices
{
    public class ContactRepositoryService : IContactRepository
    {
        public Task<bool> CreateContactAsync(Contact contactToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactByIdAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContactAsync(Contact contactToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
