using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public class AgendaPresenter
	{
		public interface IAgendaUI
		{
			void Show(List<Contact> contacts);
			void OpenContactDetailScreen(Contact contact);
		}

		readonly IAgendaUI ui;
		readonly GetContacts getContacts;

		AgendaPresenter(IAgendaUI ui, GetContacts getContacts)
		{
			this.ui = ui;
			this.getContacts = getContacts;
		}

		async Task viewDidLoad()
		{
			var contacts = await getContacts.Execute();
			ui.Show(contacts);
		}

		void itemWasTapped(Contact contact) 
		{
			ui.OpenContactDetailScreen(contact);
		}
	}
}
