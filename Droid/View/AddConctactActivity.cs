using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "AddConctactActivity")]
	public class AddConctactActivity : AppCompatActivity, AddContactPresenter.IView
	{
		AddContactPresenter presenter;

		internal static void Open(Context context)
		{
			var intent = new Intent(context, typeof(AddConctactActivity));
			context.StartActivity(intent);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AddContact);
			InitializePresenter();

			var addButton = FindViewById<Button>(Resource.Id.doneButton);
			addButton.Click += async (sender, e) =>
			{
				var firstname = FindViewById<EditText>(Resource.Id.firstnameEditText).Text;
				var lastname = FindViewById<EditText>(Resource.Id.lastnameEditText).Text;
				var phonenumber = FindViewById<EditText>(Resource.Id.phonenumberEditText).Text;
				await presenter.Add(firstname, lastname, phonenumber);
				Finish();
			};
		}

		void InitializePresenter()
		{
			presenter = App.Locator.AddContactPresenter(this);
		}
	}
}