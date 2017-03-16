using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace KataContactsCSharp.ViewModel
{
    public class ViewModelLocator
    {
		public const string AddContactPageKey = "AddContactPage";
		public const string ContactDetailsPageKey = "ContactDetailsPage";
		public const string AgendaPageKey  = "AgendaPage";

		public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<GetContacts>();
			SimpleIoc.Default.Register<AddContact>();
			SimpleIoc.Default.Register<GetContactDetail>();
			SimpleIoc.Default.Register<AgendaViewModel>();
  			SimpleIoc.Default.Register<AddContactViewModel>();
  			SimpleIoc.Default.Register<ContactDetailViewModel>();
    }

		public AgendaViewModel AgendaViewModel
        {
            get
            {
				return ServiceLocator.Current.GetInstance<AgendaViewModel>();
            }
        }

		public AddContactViewModel AddContactViewModel
		{
			get
			{
				return ServiceLocator.Current.GetInstance<AddContactViewModel>();
			}
		}

		public ContactDetailViewModel ContactDetailViewModel
		{
			get
			{
				return ServiceLocator.Current.GetInstance<ContactDetailViewModel>();
			}
		}
    }
}