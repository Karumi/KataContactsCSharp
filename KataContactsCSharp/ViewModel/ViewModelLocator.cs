using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace KataContactsCSharp.ViewModel
{
    public class ViewModelLocator
    {
		public const string AddContactPageKey = "AddContactPage";

		public const string ContactDetailsPageKey = "ContactDetailsPage";

		public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<GetContacts>();
			SimpleIoc.Default.Register<AgendaViewModel>();
        }

		public AgendaViewModel AgendaViewModel
        {
            get
            {
				return ServiceLocator.Current.GetInstance<AgendaViewModel>();
            }
        }
    }
}