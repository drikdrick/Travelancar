using PembayaranBDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PembayaranService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPembayaranService
    {

        [OperationContract]
        [FaultContract(typeof(PembayaranFault))]
        IEnumerable<Pembayaran> getPembayaranByNorek(string norek);

        [OperationContract]
        [FaultContract(typeof(PembayaranFault))]
        void DoPembayaran(string invoiceNum, string norek);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "PembayaranService.ContractType".
    [DataContract]
    public class Pembayaran
    {
        [DataMember]
        public string invoice_number { get; set; }
        [DataMember]
        public DateTime waktu_pesan { get; set; }
        [DataMember]
        public DateTime waktu_bayar { get; set; }
        [DataMember]
        public double nominal { get; set; }
        [DataMember]
        public int status_bayar { get; set; }
        [DataMember]
        public string norek_bayar { get; set; }
    }

    [DataContract]
    public class PembayaranFault
    {
        public PembayaranFault(string msg)
        {
            FaultMessage = msg;
        }
        [DataMember]
        public string FaultMessage;
    }

}
