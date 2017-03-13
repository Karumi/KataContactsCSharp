using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class AgendaViewController : UIViewController, AgendaPresenter.IAgendaUI
	{
		TableSource tableSource;

		AgendaPresenter presenter;

		public AgendaViewController(IntPtr handle) : base(handle)
		{
		}

		AgendaPresenter Presenter
		{
			get
			{
				return presenter ?? (presenter = Application.Locator.AgendaPresenter(this));
			}
		}

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		public override async void ViewDidLoad()
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
		{
			base.ViewDidLoad();

			tableSource = new TableSource(Presenter);
			tableView.Source = tableSource;
			tableView.AllowsSelection = true;

			await Presenter.ViewDidLoad();
		}

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		public override async void ViewWillAppear(bool animated)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
		{
			base.ViewWillAppear(animated);
			await Presenter.ViewWillAppear();
		}

		public void Show(List<Contact> contacts)
		{
			tableSource.Items = contacts;
			tableView.ReloadData();
		}

		public void OpenContactDetailScreen(Contact contact)
		{
			var contactDetailViewController = Storyboard.InstantiateViewController("ContactDetailViewController") as ContactDetailViewController;
			if (contactDetailViewController != null) 
			{
				contactDetailViewController.Presenter = Application.Locator.ContactDetail(contact.Id, contactDetailViewController);
				NavigationController.PushViewController(contactDetailViewController, true);
			}
		}

		partial void ButtonAddOnClick(UIBarButtonItem sender)
		{
			var addContactViewController = Storyboard.InstantiateViewController("AddContactViewController") as AddContactViewController;
			if (addContactViewController != null)
			{
				addContactViewController.Presenter = Application.Locator.AddContactPresenter(addContactViewController);
				NavigationController.PushViewController(addContactViewController, true);
			}
		}

		public class TableSource : UITableViewSource
		{
			const string CellIdentifier = "ContactCell";
			readonly AgendaPresenter presenter;

			public TableSource(AgendaPresenter presenter)
			{
				this.presenter = presenter;
			}

			internal List<Contact> Items { get; set; } = new List<Contact>();

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Items.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier);
				cell.TextLabel.Text = Items[indexPath.Row].FirstName;
				cell.UserInteractionEnabled = true;
				return cell;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				presenter.ItemSelected(Items[indexPath.Row]);
				tableView.DeselectRow(indexPath, true);
			}
		}
	}
}
