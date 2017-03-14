using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace KataContactsCSharp.Droid
{
	class AgendaAdapter : RecyclerView.Adapter
	{
		List<Contact> items;

		public AgendaAdapter(List<Contact> items)
		{
			this.items = items;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemView = LayoutInflater.From(parent.Context).
										  Inflate(Resource.Layout.ConcactCardView, parent, false);

			var vh = new ContactViewHolder(itemView);
			return vh;
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
	}
}