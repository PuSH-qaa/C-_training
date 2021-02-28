using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";

        public ContactData(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get 
            {
                return firstname;
            }
            set
            {
                this.firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                this.middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                this.lastname = value;
            }
        }
    }
}
