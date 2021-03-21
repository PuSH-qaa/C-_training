using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {


        [Test]
        public void TestContactInformationTable()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(2);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);

            //Verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationDetails()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(2);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);

            //Verification
            Assert.AreEqual(fromDetails.AllData, fromForm.AllData);
        }
    }
}

