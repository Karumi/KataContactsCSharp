using System;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class AddContactViewController : UIViewController
	{
		public AddContactViewController(IntPtr handle) : base(handle)
		{
		}

		internal AddContactViewModel ViewModel 
		{
			get { return Application.Locator.AddContactViewModel; }
		}

		public override void ViewDidLoad()
		{ 
			DoneButton.SetCommand(ViewModel.SaveCommand);
			this.SetBindings();		
		}

		void SetBindings()
		{
			this.SetBinding(
				() => ViewModel.Model.FirstName,
				() => firstNameTextField.Text,
				BindingMode.TwoWay);
			this.SetBinding(
				() => ViewModel.Model.LastName,
				() => lastNameTextField.Text,
				BindingMode.TwoWay);
			this.SetBinding(
				() => ViewModel.Model.PhoneNumber,
				() => phonenumberTextField.Text,
				BindingMode.TwoWay);
		}
	}
}