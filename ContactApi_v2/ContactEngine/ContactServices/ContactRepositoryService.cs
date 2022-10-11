using ContactEngine.ContactData;
using ContactEngine.ContactModel;
using ContactEngine.ContactsInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactEngine.ContactServices
{
    public class ContactRepositoryService : IContactRepository
    {
        public async Task<List<Contact>> GetContactsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Contacts.ToListAsync();
            }
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Contacts.FirstOrDefaultAsync(contact => contact.ContactId == contactId);
            }
        }

        public async Task<bool> CreateContactAsync(Contact contactToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Contacts.AddAsync(contactToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateContactAsync(Contact contactToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Contacts.Update(contactToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeletePostAsync(int contactId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Contact contactToDelete = await GetContactByIdAsync(contactId);

                    db.Remove(contactToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
