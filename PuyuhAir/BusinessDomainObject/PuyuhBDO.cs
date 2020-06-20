using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainObject
{
    public class PuyuhBDO
    {
        public int Penerbangan_ID { get; set; }
        public string Pesawat { get; set; }
        public int Jlh_Kursi { get; set; }
        public int Harga { get; set; }
        public string Asal { get; set; }
        public string Tujuan { get; set; }
        public DateTime Terbang { get; set; }

        public PuyuhBDO GetProduct(int id)
        {
            PuyuhBDO puyuhBDO = null;
            using (var PAEntities = new PuyuhAirEntities())
            {
                Penerbangan penerbangan = (from p in PAEntities.Penerbangan
                                           where p.PenerbanganID == id
                                           select p).FirstOrDefault();
                if (penerbangan != null)
                {
                    puyuhBDO = new PuyuhBDO()
                    {
                        Penerbangan_ID = penerbangan.PenerbanganID,
                        Pesawat = penerbangan.Pesawat,
                        Jlh_Kursi = (int)penerbangan.JlhKursi,
                        Harga = (int)penerbangan.Harga,
                        Asal = penerbangan.Asal,
                        Tujuan = penerbangan.Tujuan,
                        Terbang = (DateTime)penerbangan.Terbang
                    };
                }
            }
            return puyuhBDO;
        }

        public bool UpdateProduct(ref PuyuhBDO puyuhBDO, ref string message)
        {
            message = "Flight updated successfully";
            bool ret = true;

            using (var PAEntities = new PuyuhAirEntities())
            {
                var penerbanganID = puyuhBDO.Penerbangan_ID;
                Penerbangan penerbanganInDB = (from p in PAEntities.Penerbangan
                                               where p.PenerbanganID == penerbanganID
                                               select p).FirstOrDefault();
                if (penerbanganInDB == null)
                {
                    throw new Exception("No flight(s) found with ID " + puyuhBDO.Penerbangan_ID);
                }

                PAEntities.Penerbangan.Remove(penerbanganInDB);
                penerbanganInDB.Pesawat = puyuhBDO.Pesawat;
                penerbanganInDB.Harga = puyuhBDO.Harga;
                penerbanganInDB.Asal = puyuhBDO.Asal;
                penerbanganInDB.Tujuan = puyuhBDO.Tujuan;
                penerbanganInDB.JlhKursi = puyuhBDO.Jlh_Kursi;
                PAEntities.Entry(penerbanganInDB).State = System.Data.Entity.EntityState.Modified;
                PAEntities.SaveChanges();
            }
            return ret;
        }

        public IEnumerable<PuyuhBDO> GetAllProduct()
        {
            List<Penerbangan> li = new List<Penerbangan>();
            List<PuyuhBDO> temp = new List<PuyuhBDO>();
            using (var PAEntities = new PuyuhAirEntities())
            {
                li = (from p in PAEntities.Penerbangan select p).ToList();
            }
            foreach (var c in li)
            {
                PuyuhBDO data = new PuyuhBDO()
                {
                    Penerbangan_ID = c.PenerbanganID,
                    Pesawat = c.Pesawat,
                    Jlh_Kursi = (int)c.JlhKursi,
                    Harga = (int)c.Harga,
                    Asal = c.Asal,
                    Tujuan = c.Tujuan,
                    Terbang = (DateTime)c.Terbang
                };
                temp.Add(data);
            }
            return temp;
        }

        public void InsertProduct(PuyuhBDO puyuh)
        {
            Penerbangan penerbangan = new Penerbangan()
            {
                PenerbanganID = puyuh.Penerbangan_ID,
                Pesawat = puyuh.Pesawat,
                JlhKursi = (int)puyuh.Jlh_Kursi,
                Harga = (int)puyuh.Harga,
                Asal = puyuh.Asal,
                Tujuan = puyuh.Tujuan,
                Terbang = (DateTime)puyuh.Terbang
            };
            /*Console.WriteLine(pinguin.Penerbangan_ID);*/
            using (var PAEntities = new PuyuhAirEntities())
            {
                PAEntities.Penerbangan.Add(penerbangan);
                PAEntities.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var PAEntities = new PuyuhAirEntities())
            {
                var c = (from p in PAEntities.Penerbangan where p.PenerbanganID == id select p).First();
                PAEntities.Penerbangan.Remove(c);
                PAEntities.SaveChanges();
            }
        }
    }
}
