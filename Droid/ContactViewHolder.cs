using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

namespace KataContactsCSharp.Droid
{

	public class ContactViewHolder : RecyclerView.ViewHolder
	{
		public TextView Caption { get; private set; }

		public ContactViewHolder(View itemView) : base(itemView)
		{
			Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
		}
	}
}
