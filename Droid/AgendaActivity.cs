using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "KataContactsCSharp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		RecyclerView recyclerView;
		RecyclerView.LayoutManager layoutManager;
		AgendaAdapter adapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agenda);
			recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			layoutManager = new LinearLayoutManager(this);
			recyclerView.SetLayoutManager(layoutManager);

			var contacts = new List<Contact>();
			adapter = new AgendaAdapter(contacts);
			recyclerView.SetAdapter(adapter);
		}
	}
}

