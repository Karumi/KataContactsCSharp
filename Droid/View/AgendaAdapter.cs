using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using KataContactsCSharp.iOS;

namespace KataContactsCSharp.Droid
{
	class AgendaAdapter : RecyclerView.Adapter
	{
		readonly AgendaPresenter presenter;

		List<Contact> items;

		public AgendaAdapter(AgendaPresenter presenter)
		{
			this.presenter = presenter;
			items = new List<Contact>();
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemView = LayoutInflater.From(parent.Context).
										  Inflate(Resource.Layout.ConcactCardView, parent, false);

			return new ContactViewHolder(itemView, presenter);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var vh = holder as ContactViewHolder;
			vh.Caption.Text = items[position].FirstName;
		}

		public override int ItemCount
		{
			get
			{
				return items.Count;
			}
		}

		internal void AddAll(List<Contact> contacts)
		{
			items = contacts;
		}
	}
}