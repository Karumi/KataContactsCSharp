﻿using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using NUnit.Framework;
namespace KataContactsCSharp.Tests
{
	[TestFixture]
	public class AgendaTest
	{
		const string ANY_FIRST_NAME = "Pedro Vicente";
		const string ANY_LAST_NAME = "Gomez Sanchez";
		const string ANY_PHONE_NUMBER = "666666666";

		ContactDataSource contactDatasource { get; set; }

		[SetUp]
		public void Init()
		{
			contactDatasource = new ContactDataSource();
		}


		[Test]
		public async Task shouldReturnAnEmptyListOfContactsIfTheAgendaIsEmpty()
		{
			var getContacs = givenAnGetContactsUseCase();

			var contacts = await getContacs.Execute();

			Assert.That(contacts, Is.Empty);
		}

		[Test]
		public async Task shouldReturnTheContactCreatedOnContactAdded()
		{
			var addContact = givenAnAddContactUseCase();
			var contactToAdd = givenAnyContact();

			var createdContact = await addContact.Execute(contactToAdd);

			Assert.That(createdContact, Is.EqualTo(contactToAdd));
		}

		[Test]
		public async Task shouldReturnTheNewContactAfterTheCreationUsingGetContacts()
		{
			var getContacs = givenAnGetContactsUseCase();
			var addContact = givenAnAddContactUseCase();

			var contact = givenAnyContact();

			await addContact.Execute(contact);

			var contacts = await getContacs.Execute();
			Assert.That(contacts, Contains.Item(contact));
			Assert.That(contacts.Count, Is.EqualTo(1));
		}

		GetContacts givenAnGetContactsUseCase()
		{
			var contactRepository = new ContactRepository(contactDatasource);
			var getContacts = new GetContacts(contactRepository);
			return getContacts;
		}

		AddContact givenAnAddContactUseCase()
		{
			var contactRepository = new ContactRepository(contactDatasource);
			var addContact = new AddContact(contactRepository);
			return addContact;
		}

		Contact givenAnyContact()
		{
			Contract.Ensures(Contract.Result<Contact>() != null);
			return new Contact(ANY_FIRST_NAME, ANY_LAST_NAME, ANY_PHONE_NUMBER);
		}
	}
}
