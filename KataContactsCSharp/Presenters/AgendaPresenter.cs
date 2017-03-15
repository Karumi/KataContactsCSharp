using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataContactsCSharp
{
	public class AgendaPresenter
	{
		readonly IView ui;
		readonly GetContacts getContacts;

		internal AgendaPresenter(IView ui, GetContacts getContacts)
		{
			this.ui = ui;
			this.getContacts = getContacts;
		}

		public interface IView
		{
			void Show(List<Contact> contacts);

			void OpenContactDetailScreen(Contact contact);
		}

		public async Task Initialize()
		{
			var contacts = await getContacts.Execute();
			ui.Show(contacts);
		}

		public async Task OnForeground()
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
