using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TiviK2Plus_WebServiceApp.Core
{
    [DataContract]
    public class AkhoiTestClass
    {
        private string _id = "";

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name = "";

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}