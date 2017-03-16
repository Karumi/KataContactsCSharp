using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "ContactDetailActivity")]
	public class ContactDetailActivity : Activity
	{
		const string ContactIdKey = "contact_id_key";
		ContactDetailViewModel presenter;

		public void Show(Contact contact)
		{
			FindViewById<TextView>(Resource.Id.firstnameTextView).Text = contact.FirstName;
			FindViewById<TextView>(Resource.Id.lastnameTextView).Text = contact.LastName;
			FindViewById<TextView>(Resource.Id.phonenumberTextView).Text = contact.PhoneNumber;
		}

		internal static void Open(Context context, string id)
		{
			var intent = new Intent(context, typeof(ContactDetailActivity));
			intent.PutExtra(ContactIdKey, id);
			context.StartActivity(intent);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ContactDetail);
			InitializePresenter();
		}

		async Task InitializePresenter()
		{
			var contactId = GetContactId();
			//presenter = App.Locator.ContactDetailPresenter(contactId, this);
			//await presenter.Initialize();
		}

		string GetContactId()
		{
			return Intent.Extras.GetString(ContactIdKey);
		}
	}
}
