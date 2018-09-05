using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string emails;
        private string contactInformationDetails;

        public ContactData()
        {
        }

        public ContactData(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        public ContactData(string name, string lastname, string address, string homephone, string mobilephone, string work)
        {
            Name = name;
            Lastname = lastname;

            Address = address;
            HomePhone = homephone;
            MobilePhone = mobilephone;
            WorkPhone = work;
        }

        [Column(Name = "firstname")]

        public string Name { get; set; }

        [Column(Name = "lastname")]

        public string Lastname { get; set; }

        [Column(Name = "address")]

        public string Address { get; set; }

        [Column(Name = "home")]

        public string HomePhone { get; set; }

        [Column(Name = "mobile")]

        public string MobilePhone { get; set; }

        [Column(Name = "work")]

        public string WorkPhone { get; set; }

        [Column(Name = "email")]

        public string Email1 { get; set; }

        [Column(Name = "email2")]

        public string Email2 { get; set; }

        [Column(Name = "email3")]

        public string Email3 { get; set; }

        [Column(Name = "deprecated")]

        public string Deprecated { get; set; }


        public string ContactInformationDetails
        {
            get
            {
                if (contactInformationDetails != null)
                {
                    return contactInformationDetails;
                }
                else
                {
                    return (((Name + Lastname + Address + PhoneAddSymbol("H:", HomePhone) + 
                        PhoneAddSymbol("M:", MobilePhone) + PhoneAddSymbol("W:", WorkPhone) + Email1
                        + Email2 + Email3).Trim())).Replace(" ", "");

                }
            }
            set
            {
                contactInformationDetails = value;
            }
        }

        public string AllPhones {
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

        public string Emails
        {
            get
            {
                if (emails != null)
                {
                    return emails;
                }
                else
                {
                    return (EmailCleanUp(Email1) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
                }
            }

            set
            {
                emails = value;
            }
        }

        private string PhoneAddSymbol(string index, string phone)
        {
            if (phone == "")
            {
                return "";
            }
            return (index + phone);
        }

        private string EmailCleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
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
            if (Lastname.Equals(other.Lastname) && (Name.Equals(other.Name)))
            {
                return true;
               
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname=" + Lastname + "\nname=" + Name + "\naddress=" + Address +
                "\nmemail1= " + Email1 + "\nhemail2= " + Email2 + "\nwemail3= " + Email3 +
                "\nmphone= " + MobilePhone + "\nhphone= " + HomePhone + "\nwphone= " + WorkPhone;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            
            int compared = Lastname.CompareTo(other.Lastname);
            if (compared == 0)
            {
                return Name.CompareTo(other.Name);
            }
            return compared;
        }

        [Column(Name = "id"), PrimaryKey, Identity]

        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).OrderBy(x => x.Lastname).ToList();
            }
        }
    }
}
