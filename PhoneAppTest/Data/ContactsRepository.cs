using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneAppTest.Models;

namespace PhoneAppTest.Data
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext _contactsContext;

        public ContactsRepository(ContactsContext contacts)
        {
            _contactsContext = contacts;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(Expression<Func<Contact, bool>> criteria = null)
        { 
            var query = _contactsContext.Set<Contact>().AsQueryable();
            
            if (criteria != null) query = query.Where(criteria);

            return await query.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task SaveContactsAsync(IEnumerable<Contact> contact)
        {
            _contactsContext.Contacts.AddRange(contact);
            await _contactsContext.SaveChangesAsync();
        }

        public async Task<Contact> GetByNameAsync(string name)
        {
           return await _contactsContext.Contacts.FirstOrDefaultAsync(c => 
               string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
