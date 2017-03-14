using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using KataContactsCSharp.iOS;
using System;
using Android.Support.V7.App;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "KataContactsCSharp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity, AgendaPresenter.IAgendaUI
	{
		AgendaPresenter presenter;

		AgendaAdapter adapter;

		RecyclerView recyclerView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agenda);
			recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			InitializePresenter();
			InitializeAdapter();
			InitializeRecyclerView();
			presenter.ViewDidLoad();
		}

		public void Show(List<Contact> contacts)
		{
			adapter.AddAll(contacts);
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
		}

		void InitializeRecyclerView()
		{
			var layoutManager = new LinearLayoutManager(this);
			recyclerView.SetLayoutManager(layoutManager);
			recyclerView.HasFixedSize = true;
			recyclerView.SetAdapter(adapter);
		}
	}
}

