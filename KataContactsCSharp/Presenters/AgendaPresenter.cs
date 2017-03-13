using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp.iOS
{
	public class AgendaPresenter
	{
		readonly IAgendaUI ui;
		readonly GetContacts getContacts;

		internal AgendaPresenter(IAgendaUI ui, GetContacts getContacts)
		{
			this.ui = ui;
			this.getContacts = getContacts;
		}

		public interface IAgendaUI
		{
			void Show(List<Contact> contacts);

			void OpenContactDetailScreen(Contact contact);
		}

		public async Task ViewDidLoad()
		{
			var contacts = await getContacts.Execute();
			ui.Show(contacts);
		}

		public async Task ViewWillAppear()
		{
			var contacts = await getContacts.Execute();
			ui.Show(contacts);
		}

		public void ItemSelected(Contact contact)
		{
			ui.OpenContactDetailScreen(contact);
		}

		void ItemWasTapped(Contact contact)
		{
			ui.OpenContactDetailScreen(contact);
		}
	}
}
