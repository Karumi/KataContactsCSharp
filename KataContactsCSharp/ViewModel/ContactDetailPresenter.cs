using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class ContactDetailPresenter
	{
		readonly IView ui;
		readonly GetContactDetail getContactDetail;
		readonly string id;

		public ContactDetailPresenter(string id, IView contactDetailUI, GetContactDetail getContactDetail)
		{
			this.id = id;
			ui = contactDetailUI;
			this.getContactDetail = getContactDetail;
		}

		public interface IView
		{
			void Show(Contact contact);
		}

		public async Task Initialize()
		{
			var contact = await getContactDetail.Execute(id);
			ui.Show(contact);
		}
	}
}