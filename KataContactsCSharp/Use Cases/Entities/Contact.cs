using System;
using GalaSoft.MvvmLight;

namespace KataContactsCSharp
{
	public class Contact : ObservableObject
	{
		public Contact(string firstName, string lastName, string phoneNumber)
		{
			Id = Guid.NewGuid().ToString();
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
		}

		public Contact()
		{
			Id = Guid.NewGuid().ToString();
		}
		string firstName;

		public string FirstName
		{
			get
			{
				return firstName;
			}

			set
			{
				if (Set(ref firstName, value)) 
				{
					HasChanges = true;
				}
			}
		}

		public string Id { get; private set; }
		string lastName;

		public string LastName
		{
			get
			{
				return lastName;
			}

			set
			{
				if (Set(ref lastName, value))
				{
					HasChanges = true;
				}			
			}
		}

		string phoneNumber;

		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}

			set
			{
				if (Set(ref phoneNumber, value))
				{
					HasChanges = true;
				}			
			}
		}
		bool hasChanges;

		public bool HasChanges
		{
			get
			{
				return hasChanges;
			}

			internal set
			{
				Set(ref hasChanges, value);
			}
		}
	}
}
