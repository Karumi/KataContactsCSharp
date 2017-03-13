using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class GetContacts
	{
		readonly ContactRepository contactRepository;

		public GetContacts() : this(new ContactRepository())
		{
		}

		internal GetContacts(ContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		public Task<List<Contact>> Execute()
		{
			return contactRepository.GetAll();
		}
	}
}
