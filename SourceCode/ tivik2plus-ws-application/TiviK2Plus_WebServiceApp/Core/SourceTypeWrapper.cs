using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TiviK2Plus_WebServiceApp.Core
{
    [DataContract]
    [KnownType(typeof(MmsSourceType))]
    [KnownType(typeof(RtmpSourceType))]
    public class SourceTypeWrapper
    {
        private PlaySourceType _type;

        [DataMember]
        public PlaySourceType Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}