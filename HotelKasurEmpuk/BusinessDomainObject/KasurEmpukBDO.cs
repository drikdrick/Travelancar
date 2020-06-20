using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainObject
{
    public class KasurEmpukBDO
    {
        public int Kamar_ID { get; set; }
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public string Jenis { get; set; }

        public KasurEmpukBDO GetProduct(int id)
        {
            KasurEmpukBDO kasurBDO = null;
            using (var KEEntities = new HotelKasurEmpukEntities())
            {
                Kamar kamar = (from p in KEEntities.Kamar
                               where p.kamarID == id
                               select p).FirstOrDefault();
                if (kamar != null)
                {
                    kasurBDO = new KasurEmpukBDO()
                    {
                        Kamar_ID = kamar.kamarID,
                        Jumlah = (int)kamar.Jumlah,
                        Harga = (int)kamar.Harga,
                        Jenis = kamar.Jenis,
                    };
                }
            }
            return kasurBDO;
        }

        public bool UpdateProduct(ref KasurEmpukBDO kasurBDO, ref string message)
        {
            message = "Room updated successfully";
            bool ret = true;

            using (var KEEntities = new HotelKasurEmpukEntities())
            {
                var kamar_ID = kasurBDO.Kamar_ID;
                Kamar kamarInDB = (from p in KEEntities.Kamar
                                   where p.kamarID == kamar_ID
                                   select p).FirstOrDefault();
                if (kamarInDB == null)
                {
                    throw new Exception("No room(s) found with ID " + kasurBDO.Kamar_ID);
                }

                KEEntities.Kamar.Remove(kamarInDB);
                kamarInDB.Harga = kasurBDO.Harga;
                kamarInDB.Jenis = kasurBDO.Jenis;
                kamarInDB.Jumlah = kasurBDO.Jumlah;
                KEEntities.Entry(kamarInDB).State = System.Data.Entity.EntityState.Modified;
                KEEntities.SaveChanges();
            }
            return ret;
        }

        public IEnumerable<KasurEmpukBDO> GetAllProduct()
        {
            List<Kamar> li = new List<Kamar>();
            List<KasurEmpukBDO> temp = new List<KasurEmpukBDO>();
            using (var KEEntities = new HotelKasurEmpukEntities())
            {
                li = (from p in KEEntities.Kamar select p).ToList();
            }
            foreach (var c in li)
            {
                KasurEmpukBDO data = new KasurEmpukBDO()
                {
                    Kamar_ID = c.kamarID,
                    Jumlah = (int)c.Jumlah,
                    Harga = (int)c.Harga,
                    Jenis = c.Jenis
                };
                temp.Add(data);
            }
            return temp;
        }

        public void InsertProduct(KasurEmpukBDO mawar)
        {
            Kamar penerbangan = new Kamar()
            {
                kamarID = mawar.Kamar_ID,
                Jumlah = (int)mawar.Jumlah,
                Harga = (int)mawar.Harga,
                Jenis = mawar.Jenis
            };
            /*Console.WriteLine(mawar.Penerbangan_ID);*/
            using (var KEEntities = new HotelKasurEmpukEntities())
            {
                KEEntities.Kamar.Add(penerbangan);
                KEEntities.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var KEEntities = new HotelKasurEmpukEntities())
            {
                var c = (from p in KEEntities.Kamar where p.kamarID == id select p).First();
                KEEntities.Kamar.Remove(c);
                KEEntities.SaveChanges();
            }
        }
    }
}
