using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
        private string middlename = "";
        private string nickname = "";
        private string address = "";
        private string homephone = "";
        private string mobilephone = "";
        private string byear = "";
        
        public ContactData(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        //public ContactData(string name, string middlename,
        //string lastname, string nickname, string address, string homephone, string mobilephone, string byear)
        //{
        //    this.name = name;
        //    this.middlename = middlename;
        //    this.lastname = lastname;
        //    this.nickname = nickname;
        //    this.address = address;
        //    this.homephone = homephone;
        //    this.mobilephone = mobilephone;
        //    this.byear = byear;
        //}

        public string Name { get; set; }
        public string Lastname { get; set; }

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
            return "lastname=" + Lastname + ", name=" + Name;
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

        public string Id { get; set; }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        
        
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Homephone
        {
            get
            {
                return homephone;
            }
            set
            {
                homephone = value;
            }
        }
        public string Mobilephone
        {
            get
            {
                return mobilephone;
            }
            set
            {
                mobilephone = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
    }
}
