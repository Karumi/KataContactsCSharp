using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class GetContactDetail
	{
		readonly ContactRepository contactRepository;

		public GetContactDetail() : this(new ContactRepository())
		{
		}

		internal GetContactDetail(ContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		public Task<Contact> Execute(string id)
		{
			return contactRepository.Get(id);
		}
	}
}
