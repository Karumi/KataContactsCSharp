using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "ContactDetailActivity")]
	public class ContactDetailActivity : Activity, ContactDetailPresenter.IView
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

		async Task InitializePresenter()
		{
			var contactId = getContactId();
			presenter = App.Locator.ContactDetailPresenter(contactId, this);
			await presenter.Initialize();
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
