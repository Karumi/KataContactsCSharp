using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactRepository
	{
		IDatasource Datasource { get; set; }

		public ContactRepository(IDatasource Datasource)
		{
			this.Datasource = Datasource;
		}

		internal ContactRepository() : this(ContactDataSource.Instance)
		{
		}

		internal Task<List<Contact>> GetAll()
		{
			return Datasource.GetAll();
		}

		internal Task<Contact> Add(Contact contact)
		{
			return Datasource.Add(contact);
		}

		internal Task<Contact> Get(string id)
		{
			return Datasource.Get(id);
		}
	}
}