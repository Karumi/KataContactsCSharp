namespace KataContactsCSharp.iOS
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

		public AgendaPresenter AgendaPresenter(AgendaPresenter.IAgendaUI agendaViewController)
		{
			return new AgendaPresenter(agendaViewController, GetContacts);
		}

		public AddContactPresenter AddContactPresenter(AddContactPresenter.IAddContactUI addContactViewController)
		{
			return new AddContactPresenter(addContactViewController, AddContact);
		}

		public ContactDetailPresenter ContactDetail(string id, ContactDetailPresenter.IContactDetailUI contactDetailViewController)
		{
			return new ContactDetailPresenter(id, contactDetailViewController, GetContactDetail);
		}
	}
}