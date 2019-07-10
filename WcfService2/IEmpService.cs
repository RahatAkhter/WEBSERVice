using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpService" in both code and config file together.
    [ServiceContract]
    public interface IEmpService
    {
        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(
            Method = "GET",
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            UriTemplate = "/Gettrains"
            )]
        List<ClsEmp> DoWork();

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(
            Method = "GET",
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            UriTemplate = "/Gettrains/{name}/{sname}"
            )]

        string InsertKro(string name, string sname);


    }
}
