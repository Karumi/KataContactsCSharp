
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KataContactsCSharp.iOS;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "ContactDetailActivity")]
	public class ContactDetailActivity : Activity, ContactDetailPresenter.IContactDetailUI
	{
		const string CONTACT_ID_KEY = "contact_id_key";
		ContactDetailPresenter presenter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ContactDetail);
			InitializePresenter();
		}

		internal static void Open(Context context, string id)
		{
			var intent = new Intent(context, typeof(ContactDetailActivity));
			intent.PutExtra(CONTACT_ID_KEY, id);
			context.StartActivity(intent);
		}

		private async Task InitializePresenter()
		{
			String contactId = getContactId();
			presenter = App.Locator.ContactDetail(contactId, this);
			await presenter.ViewDidLoad();
		}

		string getContactId()
		{
			return Intent.Extras.GetString(CONTACT_ID_KEY);
		}

		public void Show(Contact contact)
		{
			FindViewById<TextView>(Resource.Id.firstnameTextView).Text = contact.FirstName;
			FindViewById<TextView>(Resource.Id.lastnameTextView).Text = contact.LastName;
			FindViewById<TextView>(Resource.Id.phonenumberTextView).Text = contact.LastName;
		}
	}
}
