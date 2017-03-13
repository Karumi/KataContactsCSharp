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

		AgendaPresenter Presenter
		{
			get
			{
				return presenter ?? (presenter = Application.Locator.AgendaPresenter(this));		
			}
		}


		public AgendaViewController(IntPtr handle) : base(handle)
		{
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.tableSource = new TableSource(this.Presenter);
			tableView.Source = tableSource;
			tableView.AllowsSelection = true;

			await Presenter.ViewDidLoad();
		}

		public override async void ViewWillAppear(bool animated)
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

		partial void buttonAddOnClick(UIBarButtonItem sender)
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
			readonly AgendaPresenter presenter;

			public TableSource(AgendaPresenter presenter)
			{
				this.presenter = presenter;
			}

			internal List<Contact> Items { get; set; } = new List<Contact>();
			const string cellIdentifier = "ContactCell";


			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Items.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
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
