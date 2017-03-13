using System.Threading.Tasks;

namespace KataContactsCSharp.iOS
{
	public class AddContactPresenter
	{
		readonly AddContact addContact;

		readonly IAddContactUI addContactUI;

		public AddContactPresenter(IAddContactUI addContactUI, AddContact addContact)
		{
			this.addContact = addContact;
			this.addContactUI = addContactUI;
		}

		public interface IAddContactUI
		{
		}

		public Task<Contact> Add(string firstname, string lastname, string phonenumber)
		{
			return addContact.Execute(new Contact(firstname, lastname, phonenumber));
		}
	}
}