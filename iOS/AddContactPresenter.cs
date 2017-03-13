using System;
using System.Threading.Tasks;

namespace KataContactsCSharp.iOS
{
	class AddContactPresenter
	{
		public interface IAddContactUI
		{
		}

		AddContact AddContact { get; set; }
		IAddContactUI AddContactUI { get; set; }

		public AddContactPresenter(IAddContactUI addContactUI, AddContact addContact)
		{
			AddContact = addContact;
			AddContactUI = addContactUI;
		}

		internal Task<Contact> Add(string firstname, string lastname, string phonenumber)
		{
			return AddContact.Execute(new Contact(firstname, lastname, phonenumber));
		}
	}
}