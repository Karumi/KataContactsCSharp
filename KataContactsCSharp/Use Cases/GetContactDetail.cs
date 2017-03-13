using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class GetContactDetail
	{
		readonly ContactRepository ContactRepository;

		internal GetContactDetail(ContactRepository ContactRepository)
		{
			this.ContactRepository = ContactRepository;
		}

		public GetContactDetail() : this(new ContactRepository())
		{
		}

		public Task<Contact> Execute(string id)
		{
			return ContactRepository.Get(id);
		}
	}
}
