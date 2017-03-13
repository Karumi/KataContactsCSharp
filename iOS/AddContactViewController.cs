using System;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class AddContactViewController : UIViewController, AddContactPresenter.IAddContactUI
	{
		internal AddContactPresenter Presenter { get; set; }

		public AddContactViewController(IntPtr handle) : base(handle)
		{
		}

		async partial void doneButtonClicked(UIBarButtonItem sender)
		{
			var firstname = firstNameTextField.Text;
			var lastname = lastNameTextField.Text;
			var phonenumber = phonenumberTextField.Text;

			await Presenter.Add(firstname, lastname, phonenumber);
			NavigationController.PopViewController(true);
		}
	}
}