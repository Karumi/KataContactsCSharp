using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactDataSource : IDatasource
	{
		static ContactDataSource instance;

		public static ContactDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContactDataSource();
				}
				return instance;
			}
		}

		Dictionary<string, Contact> items { get; set; } = new Dictionary<string, Contact>();

		Task<Contact> IDatasource.Add(Contact contact)
		{
			return Task.Run(() => {
				items.Add(contact.Id, contact); 
				return contact;
			});
		}

		Task<Contact> IDatasource.Get(string id)
		{
			return Task.FromResult(items[id]);
		}

		Task<List<Contact>> IDatasource.GetAll()
		{
			return Task.FromResult(items.Values.ToList());
		}
	}
}
