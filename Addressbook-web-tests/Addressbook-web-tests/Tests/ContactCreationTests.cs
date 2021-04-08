using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : ContactTetsBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCSVFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Middlename = parts[2],
                    Address = parts[3],
                    HomePhone = parts[4],
                    MobilePhone = parts[5],
                    WorkPhone = parts[6],
                    Email0 = parts[7],
                    Email1 = parts[8],
                    Email2 = parts[9]
                });
            }
                return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts
               .AddNewContact()
               .FillContactForm(contact)
               .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //app.Auth.Logout();
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine("From UI   " + end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine("From DB   " + end.Subtract(start));
        }
    }
}
