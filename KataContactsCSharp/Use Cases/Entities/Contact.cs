using System;

namespace KataContactsCSharp
{
	public class Contact
	{
		public Contact(string firstName, string lastName, string phoneNumber)
		{
			Id = Guid.NewGuid().ToString();
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
		}

		public string FirstName { get; }

		public string Id { get; set; }

		public string LastName { get; }

		public string PhoneNumber { get; }
	}
}
