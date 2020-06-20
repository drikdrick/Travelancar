using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainObject
{
    public class MawarDBO
    {
        public int Kamar_ID { get; set; }
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public string Jenis { get; set; }

        public MawarDBO GetProduct(int id)
        {
            MawarDBO mawarBDO = null;
            using (var MMEEntities = new HotelMawarMelatiEntities())
            {
                Kamar kamar = (from p in MMEEntities.Kamar
                                           where p.kamarID == id
                                           select p).FirstOrDefault();
                if (kamar != null)
                {
                    mawarBDO = new MawarDBO()
                    {
                        Kamar_ID = kamar.kamarID,
                        Jumlah = (int)kamar.Jumlah,
                        Harga = (int)kamar.Harga,
                        Jenis = kamar.Jenis,
                    };
                }
            }
            return mawarBDO;
        }

        public bool UpdateProduct(ref MawarDBO mawarBDO, ref string message)
        {
            message = "Room updated successfully";
            bool ret = true;

            using (var MMEEntities = new HotelMawarMelatiEntities())
            {
                var kamar_ID = mawarBDO.Kamar_ID;
                Kamar kamarInDB = (from p in MMEEntities.Kamar
                                               where p.kamarID == kamar_ID
                                               select p).FirstOrDefault();
                if (kamarInDB == null)
                {
                    throw new Exception("No room(s) found with ID " + mawarBDO.Kamar_ID);
                }

                MMEEntities.Kamar.Remove(kamarInDB);
                kamarInDB.Harga = mawarBDO.Harga;
                kamarInDB.Jenis = mawarBDO.Jenis;
                kamarInDB.Jumlah = mawarBDO.Jumlah;
                MMEEntities.Entry(kamarInDB).State = System.Data.Entity.EntityState.Modified;
                MMEEntities.SaveChanges();
            }
            return ret;
        }

        public IEnumerable<MawarDBO> GetAllProduct()
        {
            List<Kamar> li = new List<Kamar>();
            List<MawarDBO> temp = new List<MawarDBO>();
            using (var MMEEntities = new HotelMawarMelatiEntities())
            {
                li = (from p in MMEEntities.Kamar select p).ToList();
            }
            foreach (var c in li)
            {
                MawarDBO data = new MawarDBO()
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

        public void InsertProduct(MawarDBO mawar)
        {
            Kamar penerbangan = new Kamar()
            {
                kamarID = mawar.Kamar_ID,
                Jumlah = (int)mawar.Jumlah,
                Harga = (int)mawar.Harga,
                Jenis = mawar.Jenis
            };
            /*Console.WriteLine(mawar.Penerbangan_ID);*/
            using (var MMEEntities = new HotelMawarMelatiEntities())
            {
                MMEEntities.Kamar.Add(penerbangan);
                MMEEntities.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var MMEEntities = new HotelMawarMelatiEntities())
            {
                var c = (from p in MMEEntities.Kamar where p.kamarID == id select p).First();
                MMEEntities.Kamar.Remove(c);
                MMEEntities.SaveChanges();
            }
        }
    }
}
