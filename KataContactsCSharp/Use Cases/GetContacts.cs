using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class GetContacts
	{
		readonly ContactRepository ContactRepository;

		internal GetContacts(ContactRepository ContactRepository)
		{
			this.ContactRepository = ContactRepository;
		}

		public GetContacts() : this(new ContactRepository())
		{
		}

		public Task<List<Contact>> Execute()
		{
			return ContactRepository.GetAll();
		}
	}
}
