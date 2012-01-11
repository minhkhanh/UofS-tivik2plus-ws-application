using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TiviK2Plus_WebServiceApp.Core
{
    [DataContract]
    public class MmsSourceType: PlaySourceType
    {
        private string _url;

        [DataMember]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public MmsSourceType()
        {
            TypeName = "mms";
        }

    }
}