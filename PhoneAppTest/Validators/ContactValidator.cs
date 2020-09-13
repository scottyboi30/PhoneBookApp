using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PhoneAppTest.Data;
using PhoneAppTest.Models;

namespace PhoneAppTest.Validators
{

    public class ContactEnumerableValidator : AbstractValidator<List<Contact>>
    {
        public ContactEnumerableValidator(IContactsRepository contactsRepository)
        {
            RuleFor(contacts => contacts).NotEmpty().WithMessage("Please provide contacts")
                .Must(contacts => !contacts.GroupBy(c => c.Name).Any(g => g.Count() > 1))
                .WithMessage("Cannot add duplicate names");

            RuleForEach(model => model)
                .SetValidator(new ContactValidator(contactsRepository));
        }
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactValidator(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
            RuleFor(c => c.Name).NotEmpty()
                .Matches("^[A-Za-z\\s]*").WithMessage(c => $"{c.Name} is not a valid name")
                .MustAsync(DuplicateName).WithMessage(c => $"Contact '{c.Name}' already exists");

            RuleFor(c => c.Number).NotEmpty()
                .Matches("((\\+[1-9]{1,3}(\\(0\\)|0)?)|0)\\d{6,10}")
                .WithMessage(c => $"{c.Number} is not a valid number");
        }

        private async Task<bool> DuplicateName(string name, CancellationToken ct)
        {
            return await _contactsRepository.GetByNameAsync(name) == null;
        }
    }
}
