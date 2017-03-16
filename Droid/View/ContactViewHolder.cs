using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	public class ContactViewHolder : RecyclerView.ViewHolder
	{
		public ContactViewHolder(View itemView) : base(itemView)
		{
			Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
		}

		public TextView Caption { get; private set; }
	}
}
