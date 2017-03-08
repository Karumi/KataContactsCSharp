using System;
namespace KataContactsCSharp
{
	public class Contact
	{
		public Contact(string firstName, string lastName, string phoneNumber)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.phoneNumber = phoneNumber;
		}

		public String firstName { get; }
		public String lastName { get; }
		public String phoneNumber { get; }
	}
}
