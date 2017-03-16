using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using KataContactsCSharp.ViewModel;

namespace KataContactsCSharp.Droid
{
	class App
	{
		static ViewModelLocator locator;

		public static ViewModelLocator Locator
		{
			get 
			{  
				if (locator == null) 
				{ 
					var nav = new NavigationService();
					nav.Configure(
						ViewModelLocator.ContactDetailsPageKey,
						typeof(ContactDetailActivity));
					nav.Configure(
						ViewModelLocator.AddContactPageKey,
						typeof(AddConctactActivity));

					SimpleIoc.Default.Register<INavigationService>(() => nav);
					SimpleIoc.Default.Register<IDialogService, DialogService>();

					locator = new ViewModelLocator();
				}

				return locator;
			}
		}
	}
}