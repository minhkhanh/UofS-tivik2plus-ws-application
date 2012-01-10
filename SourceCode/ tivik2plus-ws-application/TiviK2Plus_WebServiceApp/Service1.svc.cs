using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace TiviK2Plus_WebServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {

        #region IService1 Members

        public List<KenhTV_DTO> GetKenhTVList()
        {
            KenhTV_DAO _kenhTV_DAO = new KenhTV_DAO();
            List<KenhTV_DTO> _kenhTVList = _kenhTV_DAO.GetKenhTVList();

            return _kenhTVList;
        }

        public int Plus(int a, int b)
        {
            return a + b;
        }

        public string AkhoiTest(string id)
        {
            //CompositeType obj = new CompositeType();
            //obj.StringValue = id;

            return id;
        }

        #endregion
    }
}
