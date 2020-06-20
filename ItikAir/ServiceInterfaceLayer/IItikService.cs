using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceInterfaceLayer
{
    [ServiceContract]
    public interface IItikService
    {
        [OperationContract]
        [FaultContract(typeof(ItikFault))]
        Penerbangan GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(ItikFault))]
        IEnumerable<Penerbangan> GetAllPenerbangan();

        [OperationContract]
        [FaultContract(typeof(ItikFault))]
        void InsertProduct(Penerbangan penerbangan);

        [OperationContract]
        [FaultContract(typeof(ItikFault))]
        void DeleteProduct(int id);
        [OperationContract]
        [FaultContract(typeof(ItikFault))]
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
    public class ItikFault
    {
        public ItikFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }
}
