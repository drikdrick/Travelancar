using BusinessDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceInterfaceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPinguinService
    {
        [OperationContract]
        [FaultContract(typeof(PinguinFault))]
        Penerbangan GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(PinguinFault))]
        IEnumerable<Penerbangan> GetAllPenerbangan();

        [OperationContract]
        [FaultContract(typeof(PinguinFault))]
        void InsertProduct(Penerbangan penerbangan);

        [OperationContract]
        [FaultContract(typeof(PinguinFault))]
        void DeleteProduct(int id);
        [OperationContract]
        [FaultContract(typeof(PinguinFault))]
        bool UpdateProduct(ref Penerbangan penerbangan, ref string message);
    }

    public class Penerbangan
    {
        [DataMember]
        public int penerbanganID { get; set; }
        [DataMember]
        public string pesawat { get; set; }
        [DataMember]
        public int jlhKursi { get; set; }
        [DataMember]
        public int harga { get; set; }
        [DataMember]
        public string asal { get; set; }
        [DataMember]
        public string tujuan { get; set; }
        [DataMember]
        public DateTime terbang { get; set; }
    }

    [DataContract]
    public class PinguinFault
    {
        public PinguinFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }
}
