using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("KataContactsCSharp.Tests")]
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
