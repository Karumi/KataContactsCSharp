
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KataContactsCSharp.Droid
{
	[Activity(Label = "ContactDetailActivity")]
	public class ContactDetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}

		internal static void Open(MainActivity mainActivity, string id)
		{
			throw new NotImplementedException();
		}
	}
}
