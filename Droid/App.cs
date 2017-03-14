using KataContactsCSharp.iOS;

namespace KataContactsCSharp.Droid
{
	class App
	{
		static PresenterLocator locator;

		public static PresenterLocator Locator
		{
			get { return locator ?? (locator = new PresenterLocator()); }
		}	
	}
}