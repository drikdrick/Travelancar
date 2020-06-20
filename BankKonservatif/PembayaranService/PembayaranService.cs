using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PembayaranService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class PembayaranService : IPembayaranService
    {
        PembayaranBL.PembayaranBL pembayaranLogic = new PembayaranBL.PembayaranBL();

        public void DoPembayaran(string invoiceNum, string norek)
        {
            pembayaranLogic.DoPembayaran(invoiceNum, norek);

        }

        public IEnumerable<Pembayaran> getPembayaranByNorek(string norek)
        {
            IEnumerable<PembayaranBDO.PembayaranBDO> pembayaranBDO = null;
            try
            {
                pembayaranBDO = pembayaranLogic.getPembayaranByNorek(norek);
            }
            catch(Exception e)
            {
                string msg = e.Message;
                string reason = "Get Pembayaran Exception";
                throw new FaultException<PembayaranFault>(new PembayaranFault(msg), reason);
            }
            if(pembayaranBDO == null)
            {
                string msg = string.Format("Pembayaran tidak ditemukan");
                string reason = "getPembayaranById Empty Pembayaran";
                throw new FaultException<PembayaranFault>(new PembayaranFault(msg), reason);
            }
            List<Pembayaran> pembayarans = new List<Pembayaran>();
            foreach(var p in pembayaranBDO)
            {
                Pembayaran pembayaran = new Pembayaran();
                TranslatePembayaranBDOToPembayaranDTO(p, pembayaran);
                pembayarans.Add(pembayaran);
            }
            return pembayarans;
        }

        private void TranslatePembayaranBDOToPembayaranDTO(PembayaranBDO.PembayaranBDO pembayaranBDO, Pembayaran pembayaran)
        {
            pembayaran.invoice_number = pembayaranBDO.invoice_number;
            pembayaran.waktu_pesan = pembayaranBDO.waktu_pesan;
            pembayaran.waktu_bayar = pembayaranBDO.waktu_bayar;
            pembayaran.nominal = pembayaranBDO.nominal;
            pembayaran.status_bayar = pembayaranBDO.status_bayar;
            pembayaran.norek_bayar = pembayaranBDO.norek_bayar;
        }

        private void TranslatePembayaranDTOToPembayaranBDO(Pembayaran pembayaran, PembayaranBDO.PembayaranBDO pembayaranBDO)
        {
            pembayaranBDO.invoice_number = pembayaran.invoice_number;
            pembayaranBDO.waktu_pesan = pembayaran.waktu_pesan;
            pembayaranBDO.waktu_bayar = pembayaran.waktu_bayar;
            pembayaranBDO.nominal = pembayaran.nominal;
            pembayaranBDO.status_bayar = pembayaran.status_bayar;
            pembayaranBDO.norek_bayar = pembayaran.norek_bayar;
        }
    }
}
