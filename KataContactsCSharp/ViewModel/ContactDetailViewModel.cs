using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace KataContactsCSharp
{
	public class ContactDetailViewModel : ViewModelBase
	{
		readonly GetContactDetail getContactDetail;

		public ContactDetailViewModel(GetContactDetail getContactDetail, INavigationService navigationService)
		{
			this.getContactDetail = getContactDetail;
		}

		public Contact Model { get; set; }

		public async Task Initialize(string id)
		{
			Model = await getContactDetail.Execute(id);
		}
	}
}