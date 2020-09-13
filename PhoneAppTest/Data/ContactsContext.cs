using Microsoft.EntityFrameworkCore;
using PhoneAppTest.Models;

namespace PhoneAppTest.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
