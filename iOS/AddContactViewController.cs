using Foundation;
using System;
using UIKit;

namespace KataContactsCSharp.iOS
{
    public partial class AddContactViewController : UIViewController
    {
		readonly AddContactPresenter presenter;

        public AddContactViewController (IntPtr handle) : base (handle)
        {
        }

		partial void doneButtonClicked(UIBarButtonItem sender)
		{
			var firstname = firstNameTextField.Text;
			var lastname = lastNameTextField.Text;
			var phonenumber = phonenumberTextField.Text;

			presenter.AddContact(firstname, lastname, phonenumber);
		}
	}
}