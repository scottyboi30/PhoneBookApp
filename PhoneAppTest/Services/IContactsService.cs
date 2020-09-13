using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneAppTest.Models;

namespace PhoneAppTest.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm);
    }
}
