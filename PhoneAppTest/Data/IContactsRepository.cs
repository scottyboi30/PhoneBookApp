using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PhoneAppTest.Models;

namespace PhoneAppTest.Data
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync(Expression<Func<Contact, bool>> criteria = null);
        Task SaveContactsAsync(IEnumerable<Contact> contact);
        Task<Contact> GetByNameAsync(string name);
    }
}
