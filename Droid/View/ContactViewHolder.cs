using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	public class ContactViewHolder : RecyclerView.ViewHolder
	{
		readonly AgendaPresenter presenter;

		public ContactViewHolder(View itemView, AgendaPresenter presenter, Action<int> listener) : base(itemView)
		{
			Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
			itemView.Click += (sender, e) => listener(AdapterPosition);

			this.presenter = presenter;
		}
	
		public TextView Caption { get; private set; }
	}
}
