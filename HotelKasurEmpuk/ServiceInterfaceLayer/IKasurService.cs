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
    public interface IKasurService
    {
        [OperationContract]
        [FaultContract(typeof(KasurFault))]
        Kamar GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(KasurFault))]
        IEnumerable<Kamar> GetAllPenerbangan();

        [OperationContract]
        [FaultContract(typeof(KasurFault))]
        void InsertProduct(Kamar kamar);

        [OperationContract]
        [FaultContract(typeof(KasurFault))]
        void DeleteProduct(int id);
        [OperationContract]
        [FaultContract(typeof(KasurFault))]
        bool UpdateProduct(ref Kamar kamar, ref string message);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceInterfaceLayer.ContractType".
    [DataContract]
    public class Kamar
    {
        [DataMember]
        public int kamar_Id { get; set; }
        [DataMember]
        public string jenis { get; set; }
        [DataMember]
        public int jumlah { get; set; }
        [DataMember]
        public int harga { get; set; }
    }

    [DataContract]
    public class KasurFault
    {
        public KasurFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }
}
