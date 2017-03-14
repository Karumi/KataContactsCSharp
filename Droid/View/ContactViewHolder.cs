using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using KataContactsCSharp.iOS;

namespace KataContactsCSharp.Droid
{

	public class ContactViewHolder : RecyclerView.ViewHolder
	{
		public TextView Caption { get; private set; }

		AgendaPresenter presenter;

		public ContactViewHolder(View itemView, AgendaPresenter presenter) : base(itemView)
		{
			Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
			this.presenter = presenter;
		}
	}
}
