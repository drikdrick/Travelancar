using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PembayaranBDO
{
    public class PembayaranBDO
    {
        public string invoice_number { get; set; }
        public DateTime waktu_pesan { get; set; }
        public DateTime waktu_bayar { get; set; }
        public double nominal { get; set; }
        public int status_bayar { get; set; }
        public string norek_bayar { get; set; }
        public IEnumerable<PembayaranBDO> getPembayaranByNorek(string norek)
        {
            List<Pembayaran> lp = new List<Pembayaran>();
            List<PembayaranBDO> lpbdo = new List<PembayaranBDO>();
            
            using (var db = new BankKonservatifEntities())
            {
                lp = (from p in db.Pembayarans
                             where p.norek_bayar == norek
                             select p).ToList();            
            }
            foreach(var obj in lp)
            {
                PembayaranBDO data = new PembayaranBDO()
                {
                    invoice_number = obj.invoice_number,
                    waktu_pesan = obj.waktu_pemesanan,
                    waktu_bayar = (DateTime) obj.waktu_pembayaran,
                    nominal = obj.nominal,
                    status_bayar = obj.status_bayar,
                    norek_bayar = obj.norek_bayar
                };
                lpbdo.Add(data);
            }
            return lpbdo;
        }
        public void DoPembayaran(string invoiceNum, string norek)
        {
            using (var db = new BankKonservatifEntities())
            {
                Pembayaran dataInDb = (from p in db.Pembayarans where p.invoice_number == invoiceNum select p).FirstOrDefault();
                db.Pembayarans.Remove(dataInDb);
                dataInDb.norek_bayar = norek;
                dataInDb.waktu_pembayaran = DateTime.Now;
                dataInDb.status_bayar = 1;
                db.Pembayarans.Attach(dataInDb);
                db.Entry(dataInDb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }




}
