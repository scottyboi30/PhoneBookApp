using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PhoneAppTest.Data;
using PhoneAppTest.Models;

namespace PhoneAppTest.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return await _contactsRepository.GetContactsAsync();
            
            Expression<Func<Contact, bool>> criteria;
            if (searchTerm.Any(char.IsDigit))
            {
                criteria = x => x.Number.Equals(searchTerm);
            }
            else
            {
                criteria = x => x.Name.ToLower().Contains(searchTerm.ToLower());
            }
            return await _contactsRepository.GetContactsAsync(criteria);
        }
    }
}
