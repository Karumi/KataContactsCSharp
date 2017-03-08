using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactRepository
	{
		IDatasource Datasource { get; set; }

		internal Task<List<Contact>> GetAll()
		{
			return Datasource.GetAll();
		}

		internal Task Add(Contact contact)
		{
			return Datasource.Add(contact);
		}

		internal Task<Contact> Get(int atIndex)
		{
			return Datasource.Get(atIndex);
		}
	}
}