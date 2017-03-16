using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "KataContactsCSharp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		ObservableRecyclerAdapter<Contact, ContactViewHolder> adapter;

		RecyclerView recyclerView;

		AgendaViewModel ViewModel
		{
			get { return App.Locator.AgendaViewModel; }
		}

		public void OpenContactDetailScreen(Contact contact)
		{
			ContactDetailActivity.Open(this, contact.Id);
		}

		public void OnItemClick(int oldPosition, View oldView, int position, View view)
		{
			ViewModel.ShowContactDetailsCommand.Execute(ViewModel.Contacts[position]);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agenda);

			adapter = ViewModel.Contacts.GetRecyclerAdapter(BindViewHolder, OnCreateViewHolder, OnItemClick);

			recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
			var addButton = FindViewById<FloatingActionButton>(Resource.Id.addButton);
			addButton.Click += (sender, e) =>
			{
				AddConctactActivity.Open(this);
			};

			InitializeRecyclerView();
			ViewModel.Initialize();
		}

		void InitializeRecyclerView()
		{
			var layoutManager = new LinearLayoutManager(this);
			recyclerView.SetLayoutManager(layoutManager);
			recyclerView.HasFixedSize = true;
			recyclerView.SetAdapter(adapter);
		}
						
		void BindViewHolder(ContactViewHolder holder, Contact contact, int position)
		{
			holder.Caption.Text = contact.FirstName;
		}

		ContactViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ConcactCardView, parent, false);

			return new ContactViewHolder(itemView);
		}
	}
}
