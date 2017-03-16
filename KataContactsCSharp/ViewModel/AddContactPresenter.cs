using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class AddContactPresenter
	{
		readonly AddContact addContact;

		readonly IView addContactUI;

		public AddContactPresenter(IView addContactUI, AddContact addContact)
		{
			this.addContact = addContact;
			this.addContactUI = addContactUI;
		}

		public interface IView
		{
		}

		public Task<Contact> Add(string firstname, string lastname, string phonenumber)
		{
			return addContact.Execute(new Contact(firstname, lastname, phonenumber));
		}
	}
}