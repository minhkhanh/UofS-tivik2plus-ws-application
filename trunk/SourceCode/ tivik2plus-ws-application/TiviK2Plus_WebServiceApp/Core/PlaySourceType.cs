using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TiviK2Plus_WebServiceApp.Core
{
    [DataContract]
    public class PlaySourceType
    {
        private string _typeName = "";

        [DataMember]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
    }
}