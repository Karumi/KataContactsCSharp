using System;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class AddContactViewController : UIViewController, AddContactPresenter.IView
	{
		public AddContactViewController(IntPtr handle) : base(handle)
		{
		}

		internal AddContactPresenter Presenter { get; set; }

		async partial void DoneButtonClicked(UIBarButtonItem sender)
		{
			var firstname = firstNameTextField.Text;
			var lastname = lastNameTextField.Text;
			var phonenumber = phonenumberTextField.Text;

			await Presenter.Add(firstname, lastname, phonenumber);
			NavigationController.PopViewController(true);
		}
	}
}