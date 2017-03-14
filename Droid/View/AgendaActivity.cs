using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "KataContactsCSharp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity, AgendaPresenter.IView
	{
		AgendaPresenter presenter;

		AgendaAdapter adapter;

		RecyclerView recyclerView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agenda);
			recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
			var addButton = FindViewById<FloatingActionButton>(Resource.Id.addButton);
			addButton.Click += (sender, e) =>
			{
				AddConctactActivity.Open(this);
			};


			InitializePresenter();
			InitializeAdapter();
			InitializeRecyclerView();
			presenter.Initialize();
		}

		protected override void OnResume()
		{
			base.OnResume();

			presenter.OnForeground();
		}

		public void Show(List<Contact> contacts)
		{
			adapter.AddAll(contacts);
			adapter.NotifyDataSetChanged();
		}

		public void OpenContactDetailScreen(Contact contact)
		{
			ContactDetailActivity.Open(this, contact.Id);
		}

		void InitializePresenter()
		{
			presenter = App.Locator.AgendaPresenter(this);
		}

		void InitializeAdapter()
		{
			adapter = new AgendaAdapter(presenter);
			adapter.ItemClick += OnItemClick;
		}

		void InitializeRecyclerView()
		{
			var layoutManager = new LinearLayoutManager(this);
			recyclerView.SetLayoutManager(layoutManager);
			recyclerView.HasFixedSize = true;
			recyclerView.SetAdapter(adapter);
		}

		void OnItemClick(object sender, Contact contact)
		{
			ContactDetailActivity.Open(this, contact.Id);
		}
	}
}

