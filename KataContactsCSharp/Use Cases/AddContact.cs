using System;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class AddContact
	{
		readonly ContactRepository ContactRepository;

		internal AddContact(ContactRepository ContactRepository)
		{
			this.ContactRepository = ContactRepository;
		}

		public AddContact() : this(new ContactRepository())
		{
		}

		public Task Execute(Contact contact)
		{
			return ContactRepository.Add(contact);
		}
	}
}
