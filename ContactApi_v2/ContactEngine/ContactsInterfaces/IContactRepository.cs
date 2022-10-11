using ContactEngine.ContactModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEngine.ContactsInterfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> GetContactByIdAsync(int contactId);
        Task<bool> CreateContactAsync(Contact contactToCreate);
        Task<bool> UpdateContactAsync(Contact contactToUpdate);
        Task<bool> DeletePostAsync(int contactId);
    }
}