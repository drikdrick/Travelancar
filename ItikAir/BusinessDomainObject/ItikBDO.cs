using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainObject
{
    public class ItikBDO
    {
        public int Penerbangan_ID { get; set; }
        public string Pesawat { get; set; }
        public int Jlh_Kursi { get; set; }
        public int Harga { get; set; }
        public string Asal { get; set; }
        public string Tujuan { get; set; }
        public DateTime Terbang { get; set; }

        public ItikBDO GetProduct(int id)
        {
            ItikBDO pinguinBDO = null;
            using (var PAEntities = new ItikAirEntities())
            {
                Penerbangan penerbangan = (from p in PAEntities.Penerbangan
                                           where p.PenerbanganID == id
                                           select p).FirstOrDefault();
                if (penerbangan != null)
                {
                    pinguinBDO = new ItikBDO()
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
            return pinguinBDO;
        }

        public bool UpdateProduct(ref ItikBDO pinguinBDO, ref string message)
        {
            message = "Flight updated successfully";
            bool ret = true;

            using (var PAEntities = new ItikAirEntities())
            {
                var penerbanganID = pinguinBDO.Penerbangan_ID;
                Penerbangan penerbanganInDB = (from p in PAEntities.Penerbangan
                                               where p.PenerbanganID == penerbanganID
                                               select p).FirstOrDefault();
                if (penerbanganInDB == null)
                {
                    throw new Exception("No flight(s) found with ID " + pinguinBDO.Penerbangan_ID);
                }

                PAEntities.Penerbangan.Remove(penerbanganInDB);
                penerbanganInDB.Pesawat = pinguinBDO.Pesawat;
                penerbanganInDB.Harga = pinguinBDO.Harga;
                penerbanganInDB.Asal = pinguinBDO.Asal;
                penerbanganInDB.Tujuan = pinguinBDO.Tujuan;
                penerbanganInDB.JlhKursi = pinguinBDO.Jlh_Kursi;
                PAEntities.Entry(penerbanganInDB).State = System.Data.Entity.EntityState.Modified;
                PAEntities.SaveChanges();
            }
            return ret;
        }

        public IEnumerable<ItikBDO> GetAllProduct()
        {
            List<Penerbangan> li = new List<Penerbangan>();
            List<ItikBDO> temp = new List<ItikBDO>();
            using (var PAEntities = new ItikAirEntities())
            {
                li = (from p in PAEntities.Penerbangan select p).ToList();
            }
            foreach (var c in li)
            {
                ItikBDO data = new ItikBDO()
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

        public void InsertProduct(ItikBDO pinguin)
        {
            Penerbangan penerbangan = new Penerbangan()
            {
                PenerbanganID = pinguin.Penerbangan_ID,
                Pesawat = pinguin.Pesawat,
                JlhKursi = (int)pinguin.Jlh_Kursi,
                Harga = (int)pinguin.Harga,
                Asal = pinguin.Asal,
                Tujuan = pinguin.Tujuan,
                Terbang = (DateTime)pinguin.Terbang
            };
            /*Console.WriteLine(pinguin.Penerbangan_ID);*/
            using (var PAEntities = new ItikAirEntities())
            {
                PAEntities.Penerbangan.Add(penerbangan);
                PAEntities.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var PAEntities = new ItikAirEntities())
            {
                var c = (from p in PAEntities.Penerbangan where p.PenerbanganID == id select p).First();
                PAEntities.Penerbangan.Remove(c);
                PAEntities.SaveChanges();
            }
        }
    }
}
