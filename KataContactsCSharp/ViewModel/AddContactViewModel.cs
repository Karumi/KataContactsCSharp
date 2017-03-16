using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using KataContactsCSharp.ViewModel;

namespace KataContactsCSharp
{
	public class AddContactViewModel : ViewModelBase
	{
		readonly AddContact addContact;

		readonly INavigationService navigationService;

		public AddContactViewModel(AddContact addContact, INavigationService navigationService)
		{
			this.addContact = addContact;
			this.navigationService = navigationService;
			this.SaveCommand = new RelayCommand(Add, CanAdd);

            Model.PropertyChanged += (s, e) =>
			{
				if (e.PropertyName == nameof(Contact.HasChanges))
				{
					SaveCommand.RaiseCanExecuteChanged();
				}
			};
		}

		public Contact Model { get; } = new Contact();

		public RelayCommand SaveCommand { get; }

		public bool IsSaving { get; private set; }

		public void Add()
		{
			IsSaving = true;
			SaveCommand.RaiseCanExecuteChanged();

			var contact = addContact.Execute(Model);

			IsSaving = false;
			SaveCommand.RaiseCanExecuteChanged();

			this.navigationService.GoBack();
		}

		public bool CanAdd() 
		{
			return !IsSaving && Model.HasChanges;
		}
	}
}