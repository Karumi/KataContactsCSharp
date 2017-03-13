using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public partial class AgendaViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, AgendaPresenter.IAgendaUI
	{
		List<Contact> items { get; set; } = new List<Contact>();
		const string cellIdentifier = "ContactCell";
		
		public AgendaViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			tableView.DataSource = this;
			tableView.Delegate = this;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			cell.TextLabel.Text = items[indexPath.Row].firstName;
			return cell;
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return items.Count;
		}

		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
		    tableView.DeselectRow(indexPath, true);
		}

		public void Show(List<Contact> contacts)
		{
			items = contacts;
		}

		public void OpenContactDetailScreen(Contact contact)
		{
			throw new NotImplementedException();
		}

		partial void buttonAddOnClick(UIBarButtonItem sender)
		{
		}
	}
}
