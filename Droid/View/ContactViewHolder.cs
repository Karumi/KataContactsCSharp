using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using KataContactsCSharp.iOS;
using System;

namespace KataContactsCSharp.Droid
{

	public class ContactViewHolder : RecyclerView.ViewHolder
	{
		public TextView Caption { get; private set; }

		AgendaPresenter presenter;

		public ContactViewHolder(View itemView, AgendaPresenter presenter, Action<int> listener) : base(itemView)
		{
			Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
			itemView.Click += (sender, e) => listener(base.AdapterPosition);

			this.presenter = presenter;
		}
	}
}
