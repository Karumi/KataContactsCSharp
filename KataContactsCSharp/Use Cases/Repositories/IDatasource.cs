using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	interface IDatasource
	{
		Task<List<Contact>> GetAll();

		Task<Contact> Add(Contact contact);

		Task<Contact> Get(string id);
	}
}