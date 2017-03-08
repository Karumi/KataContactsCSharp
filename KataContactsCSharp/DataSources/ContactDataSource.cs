using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactDataSource : IDatasource
	{
		List<Contact> items { get; set; } = new List<Contact>();

		Task<Contact> IDatasource.Add(Contact contact)
		{
			return Task.Run(() => {
				items.Add(contact); 
				return contact;
			});
		}

		Task<Contact> IDatasource.Get(int index)
		{
			return Task.FromResult(items[index]);
		}

		Task<List<Contact>> IDatasource.GetAll()
		{
			return Task.FromResult(items);
		}
	}
}
