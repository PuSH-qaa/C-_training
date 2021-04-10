using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    class RemovingContactsFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactsFromGroupTest()
        {
            GroupData group = GroupData.GetAll()[0];

            app.Contacts.CheckAndAddContactsToGroupIfItIsNot(group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Intersect(oldList).First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            Assert.AreEqual(oldList.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newList = group.GetContacts();

            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        } 
    }
}
