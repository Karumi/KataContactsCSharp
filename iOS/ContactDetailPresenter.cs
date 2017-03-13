using System;

namespace KataContactsCSharp.iOS
{
	public class ContactDetailPresenter
	{
		public interface IContactDetailUI
		{
			void Show(Contact contact);
		}


		readonly IContactDetailUI ui;
		readonly GetContactDetail getContactDetail;
		readonly string id;


		public ContactDetailPresenter(string id, IContactDetailUI contactDetailUI, GetContactDetail getContactDetail)
		{
			this.id = id;
			this.ui = contactDetailUI;
			this.getContactDetail = getContactDetail;
		}

		internal async void ViewDidLoad()
		{
			var contact = await getContactDetail.Execute(id);
			ui.Show(contact);
		}
	}
}