using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	interface IDatasource
	{
		Task<List<Contact>> GetAll();
		Task Add(Contact contact);
		Task<Contact> Get(int index);
	}
}