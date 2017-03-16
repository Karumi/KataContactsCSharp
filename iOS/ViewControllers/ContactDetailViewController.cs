using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class ContactDetailViewController : UIViewController
	{
		public ContactDetailViewController(IntPtr handle) : base(handle)
		{
		}

		NavigationService Nav => ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;

		ContactDetailViewModel ViewModel
		{
			get { return Application.Locator.ContactDetailViewModel; }
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.SetBindings();

			var id = (string) Nav.GetAndRemoveParameter(this);
			ViewModel.Initialize(id);
		}

		void SetBindings() 
		{
			this.SetBinding(
				() => ViewModel.Model.FirstName,
				() => FirstnameLabel.Text);
			this.SetBinding(
				() => ViewModel.Model.LastName,
				() => LastNameLabel.Text);
			this.SetBinding(
				() => ViewModel.Model.PhoneNumber,
				() => PhonenumberLabel.Text);
		}
	}
}