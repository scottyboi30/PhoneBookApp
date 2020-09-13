using System.ComponentModel.DataAnnotations;

namespace PhoneAppTest.Models
{
    public class Contact
    {
        [Key]
        public string Name { get; set; }

        public string Number { get; set; }
    }
}
