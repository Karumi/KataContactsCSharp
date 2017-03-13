using System.Threading.Tasks;

namespace KataContactsCSharp.iOS
{
	public class AddContactPresenter
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

		public Task<Contact> Add(string firstname, string lastname, string phonenumber)
		{
			return AddContact.Execute(new Contact(firstname, lastname, phonenumber));
		}
	}
}