using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return ("firstname=" + Firstname) + ("lastname=" + Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email0 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string AllPhones 
        { 
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            } 
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EmailRowUpdate(Email0) + EmailRowUpdate(Email1) + EmailRowUpdate(Email2)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return (NameRowUpdate(Firstname, Middlename, Lastname) + AddressRowUpdate(Address) + 
                        NewBlockRedirect(HomePhone, MobilePhone, WorkPhone) + EmailRowUpdate(Email0) +
                        EmailRowUpdate(Email1) + EmailRowUpdate(Email2)).Trim();
                }
            }
            set
            {
                allData = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[-( )]", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string NameRowUpdate(string firstname, string middlename, string lastname)
        {
            if ( firstname == null || firstname == "")
            {
                if( middlename == null || middlename == "")
                {
                    if(lastname == null || lastname == "")
                    {
                        return "";
                    }
                    return Regex.Replace(lastname, @"\s+", " ").Trim() + "\r\n";
                }
                return Regex.Replace(middlename + " " + lastname, @"\s+", " ").Trim() + "\r\n";
            }
            string names = firstname + " " + middlename + " " + lastname + "\r\n";
            return Regex.Replace(names, @"\s+", " ").Trim() + "\r\n"; 
        }

        private string AddressRowUpdate(string address)
        {
            if ( address == null || address == "")
            {
                return "\r\n";            
            }
            return Regex.Replace(address, @"\s+", " ").Trim() + "\r\n" + "\r\n";
        }

        private string HomePhoneRowUpdate(string home)
        {
            if( home == null || home == "")
            {
                return "";
            }
            return Regex.Replace("H: " + home, @"\s+", " ").Trim() + "\r\n";
        }

        private string MobilePhoneRowUpdate(string mobile)
        {
            if (mobile == null || mobile == "")
            {
                return "";
            }
            return Regex.Replace("M: " + mobile, @"\s+", " ").Trim() + "\r\n";
        }

        private string WorkPhoneRowUpdate(string work)
        {
            if (work == null || work == "")
            {
                return "";
            }
            return Regex.Replace("W: " + work, @"\s+", " ").Trim() + "\r\n";
        }

        private string NewBlockRedirect(string home, string mobile, string work)
        {
            if ((home == null || home == "") && (mobile == null || mobile == "") && (work == null || work == ""))
            {
                return "";
            }
            return HomePhoneRowUpdate(home) + MobilePhoneRowUpdate(mobile) + WorkPhoneRowUpdate(work) + "\r\n";
        }

        private string EmailRowUpdate(string email)
        {
            if ( email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, @"\s+", " ").Trim() + "\r\n";
        }
    }
}
