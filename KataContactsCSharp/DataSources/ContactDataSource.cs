using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	class ContactDataSource : IDatasource
	{
		static ContactDataSource instance;
		readonly Dictionary<string, Contact> items = new Dictionary<string, Contact>();

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

		Task<Contact> IDatasource.Add(Contact contact)
		{
			return Task.Run(() =>
			{
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
