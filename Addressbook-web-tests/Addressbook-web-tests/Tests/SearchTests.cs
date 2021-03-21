using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {


        [Test]
        public void SearchTest()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }
    }
}
