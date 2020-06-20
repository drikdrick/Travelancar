using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PembayaranBL
{
    public class PembayaranBL
    {
        PembayaranBDO.PembayaranBDO pembayaranBDO = new PembayaranBDO.PembayaranBDO();
        public IEnumerable<PembayaranBDO.PembayaranBDO> getPembayaranByNorek(string norek)
        {
            return pembayaranBDO.getPembayaranByNorek(norek);
        }

        public void DoPembayaran(string invoiceNum, string norek)
        {
            pembayaranBDO.DoPembayaran(invoiceNum, norek);
        }
    }
}
