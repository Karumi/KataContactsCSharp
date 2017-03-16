using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using KataContactsCSharp.ViewModel;

namespace KataContactsCSharp
{
	public class AgendaViewModel : ViewModelBase
	{
		readonly GetContacts getContacts;
		readonly INavigationService navigationService;

		public AgendaViewModel(GetContacts getContacts, INavigationService navigationService)
		{
			this.getContacts = getContacts;
			this.navigationService = navigationService;

			this.ShowContactDetailsCommand = new RelayCommand<Contact>(this.ItemSelected);
			this.AddContactCommand = new RelayCommand(this.AddItem);
		}

		public ObservableCollection<Contact> Contacts { get; private set; }

		public RelayCommand<Contact> ShowContactDetailsCommand { get; }

		public RelayCommand AddContactCommand { get; }

		public async Task Initialize()
		{
			var contacts = await this.getContacts.Execute();
			Contacts = new ObservableCollection<Contact>(contacts);
		}

		void ItemSelected(Contact contact)
		{
			this.navigationService.NavigateTo(ViewModelLocator.ContactDetailsPageKey, contact.Id);
		}

		void AddItem()
		{
			this.navigationService.NavigateTo(ViewModelLocator.AddContactPageKey);
		}
	}
}
