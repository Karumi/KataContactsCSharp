using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace KataContactsCSharp.iOS
{
	public partial class AgendaViewController : UIViewController
	{
		const string CellIdentifier = "ContactCell";
		ObservableTableViewSource<Contact> tableSource;


		public AgendaViewController(IntPtr handle) : base(handle)
		{
		}

		private AgendaViewModel ViewModel
		{
			get { return Application.Locator.AgendaViewModel; }
		}

		public override void ViewDidLoad()
		{
			this.buttonAdd.SetCommand(ViewModel.AddContactCommand);


			this.tableSource = ViewModel.Contacts.GetTableViewSource(
				BindContactCell,
				CellIdentifier);
			tableView.RegisterClassForCellReuse(typeof(UITableViewCell), new NSString(CellIdentifier));
			tableView.Source = tableSource;
			tableView.AllowsSelection = true;

			tableSource.SelectionChanged +=
				           (s, e) => ViewModel.ShowContactDetailsCommand.Execute(tableSource.SelectedItem);

			base.ViewDidLoad();
		}

		private void BindContactCell(UITableViewCell cell, Contact contact, NSIndexPath path)
		{
			cell.TextLabel.Text = contact.FirstName;
		}
	}
}
