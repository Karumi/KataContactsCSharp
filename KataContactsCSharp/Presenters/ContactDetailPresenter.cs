using System.Threading.Tasks;

namespace KataContactsCSharp.iOS
{
	public class ContactDetailPresenter
	{
		public interface IContactDetailUI
		{
			void Show(Contact contact);
		}


		readonly IContactDetailUI ui;
		readonly GetContactDetail getContactDetail;
		readonly string id;


		public ContactDetailPresenter(string id, IContactDetailUI contactDetailUI, GetContactDetail getContactDetail)
		{
			this.id = id;
			ui = contactDetailUI;
			this.getContactDetail = getContactDetail;
		}

		public async Task ViewDidLoad()
		{
			var contact = await getContactDetail.Execute(id);
			ui.Show(contact);
		}
	}
}