using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class AddContact
	{
		readonly ContactRepository contactRepository;

		public AddContact() : this(new ContactRepository())
		{
		}

		internal AddContact(ContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		public Task<Contact> Execute(Contact contact)
		{
			return contactRepository.Add(contact);
		}
	}
}
