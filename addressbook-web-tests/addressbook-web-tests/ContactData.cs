﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class ContactData
    {
        private string name;
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string address = "";
        private string homephone = "";
        private string mobilephone = "";
        private string byear = "";
        
        public ContactData(string name)
        {
            this.name = name;
        }

        public ContactData(string name, string middlename,
        string lastname, string nickname, string address, string homephone, string mobilephone, string byear)
        {
            this.name = name;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.address = address;
            this.homephone = homephone;
            this.mobilephone = mobilephone;
            this.byear = byear;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
                middlename = value;
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
                lastname = value;
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
