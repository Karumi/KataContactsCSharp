using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace KataContactsCSharp.iOS
{
	public class Application
	{
		static PresenterLocator locator;

		public static PresenterLocator Locator
		{
			get { return locator ?? (locator = new PresenterLocator()); }
		}

		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}
