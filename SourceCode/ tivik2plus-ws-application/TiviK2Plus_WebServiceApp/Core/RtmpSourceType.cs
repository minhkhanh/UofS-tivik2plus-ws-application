using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TiviK2Plus_WebServiceApp.Core
{
    [DataContract]
    public class RtmpSourceType: PlaySourceType
    {
        private string _paramStreamer;

        [DataMember]
        public string ParamStreamer
        {
            get { return _paramStreamer; }
            set { _paramStreamer = value; }
        }
        private string _paramFile;

        [DataMember]
        public string ParamFile
        {
            get { return _paramFile; }
            set { _paramFile = value; }
        }

        public RtmpSourceType()
        {
            TypeName = "rtmp";
        }
    }
}