using System;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class ContactDetailViewController : UIViewController, ContactDetailPresenter.IView
	{
		public ContactDetailViewController(IntPtr handle) : base(handle)
		{
		}

		public ContactDetailPresenter Presenter { get; internal set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Presenter.Initialize();
		}

		public void Show(Contact contact)
		{
			FirstnameLabel.Text = contact.FirstName;
			LastNameLabel.Text = contact.LastName;
			PhonenumberLabel.Text = contact.PhoneNumber;
		}
	}
}