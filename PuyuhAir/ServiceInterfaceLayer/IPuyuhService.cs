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
    public interface IPuyuhService
    {
        [OperationContract]
        [FaultContract(typeof(PuyuhFault))]
        Penerbangan GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(PuyuhFault))]
        IEnumerable<Penerbangan> GetAllPenerbangan();

        [OperationContract]
        [FaultContract(typeof(PuyuhFault))]
        void InsertProduct(Penerbangan penerbangan);

        [OperationContract]
        [FaultContract(typeof(PuyuhFault))]
        void DeleteProduct(int id);
        [OperationContract]
        [FaultContract(typeof(PuyuhFault))]
        bool UpdateProduct(ref Penerbangan penerbangan, ref string message);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceInterfaceLayer.ContractType".
    [DataContract]
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
    public class PuyuhFault
    {
        public PuyuhFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }
}
