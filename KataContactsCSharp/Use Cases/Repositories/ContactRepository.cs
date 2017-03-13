using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactRepository
	{
		readonly IDatasource datasource;

		public ContactRepository(IDatasource datasource)
		{
			this.datasource = datasource;
		}

		internal ContactRepository() : this(ContactDataSource.Instance)
		{
		}

		internal Task<List<Contact>> GetAll()
		{
			return datasource.GetAll();
		}

		internal Task<Contact> Add(Contact contact)
		{
			return datasource.Add(contact);
		}

		internal Task<Contact> Get(string id)
		{
			return datasource.Get(id);
		}
	}
}