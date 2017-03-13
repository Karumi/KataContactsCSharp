namespace KataContactsCSharp.iOS
{
	public class PresenterLocator
	{
		internal AgendaPresenter AgendaPresenter(AgendaViewController agendaViewController)
		{
			return new AgendaPresenter(agendaViewController, GetContacts);
		}

		internal AddContactPresenter AddContactPresenter(AddContactViewController addContactViewController)
		{
			return new AddContactPresenter(addContactViewController, AddContact);
		}

		internal ContactDetailPresenter ContactDetail(string id, ContactDetailViewController contactDetailViewController)
		{
			return new ContactDetailPresenter(id, contactDetailViewController, GetContactDetail);
		}


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
	}
}