namespace KataContactsCSharp
{
	public class PresenterLocator
	{
		GetContacts GetContacts
		{
			get
			{
				return new GetContacts();
			}
		}

		GetContactDetail GetContactDetail
		{
			get
			{
				return new GetContactDetail();
			}
		}

		AddContact AddContact
		{
			get
			{
				return new AddContact();
			}
		}

		public AgendaPresenter AgendaPresenter(AgendaPresenter.IView agendaViewController)
		{
			return new AgendaPresenter(agendaViewController, GetContacts);
		}

		public AddContactPresenter AddContactPresenter(AddContactPresenter.IView addContactViewController)
		{
			return new AddContactPresenter(addContactViewController, AddContact);
		}

		public ContactDetailPresenter ContactDetailPresenter(string id, ContactDetailPresenter.IView contactDetailViewController)
		{
			return new ContactDetailPresenter(id, contactDetailViewController, GetContactDetail);
		}
	}
}