using BusinessDomainObject;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceInterfaceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class KasurService : IKasurService
    {
        KasurLogic kasurLogic = new KasurLogic();
        public Kamar GetProduct(int id)
        {
            KasurEmpukBDO kasurBDO = null;
            try
            {
                kasurBDO = kasurLogic.GetProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetProduct Fail!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }
            if (kasurBDO == null)
            {
                string msg = string.Format("No room found for id {0}", id);
                string reason = "Empty room!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }

            Kamar kamar = new Kamar();
            MawarBDOToPenerbanganDTO(kasurBDO, kamar);
            return kamar;
        }

        public IEnumerable<Kamar> GetAllPenerbangan()
        {
            IEnumerable<KasurEmpukBDO> temp = null;
            try
            {
                temp = kasurLogic.GetAllProduct();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetAll Fail!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }
            if (temp == null)
            {
                string msg = string.Format("No room found!");
                string reason = "No room available!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }
            List<Kamar> penerbangans = new List<Kamar>();
            foreach (var c in temp)
            {
                Kamar kamar = new Kamar();
                MawarBDOToPenerbanganDTO(c, kamar);
            }
            return penerbangans;
        }

        public void InsertProduct(Kamar kamar)
        {
            try
            {
                KasurEmpukBDO kasurBDO = KamarDTOToMawarBDO(kamar);

                kasurLogic.InsertProduct(kasurBDO);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Insert Fail!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }
        }

        public bool UpdateProduct(ref Kamar kamar, ref string message)
        {
            bool result = true;
            if (kamar.harga <= 0)
            {
                message = "Price cannot be <=0";
                result = false;
            }
            else if (kamar.jumlah <= 0)
            {
                message = "Total room cannot be <=0";
                result = false;
            }
            else
            {
                try
                {
                    KasurEmpukBDO kasurBDO = KamarDTOToMawarBDO(kamar);
                    result = kasurLogic.UpdatedProduct(ref kasurBDO, ref message);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw new FaultException<KasurFault>
                     (new KasurFault(msg), msg);
                }
            }
            return result;
        }

        public void DeleteProduct(int id)
        {
            try
            {
                kasurLogic.DeleteProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Delete Fail!";
                throw new FaultException<KasurFault>(new KasurFault(msg), reason);
            }
        }

        public void MawarBDOToPenerbanganDTO(KasurEmpukBDO kasurBDO, Kamar kamar)
        {
            kamar.kamar_Id = kasurBDO.Kamar_ID;
            kamar.jumlah = (int)kasurBDO.Jumlah;
            kamar.harga = (int)kasurBDO.Harga;
            kamar.jenis = kasurBDO.Jenis;
        }

        public KasurEmpukBDO KamarDTOToMawarBDO(Kamar kamar)
        {
            KasurEmpukBDO kasurBDO = new KasurEmpukBDO();
            kasurBDO.Kamar_ID = kamar.kamar_Id;
            kasurBDO.Jenis = kamar.jenis;
            kasurBDO.Harga = (int)kamar.harga;
            kasurBDO.Jumlah = (int)kamar.jumlah;

            return kasurBDO;
        }
    }
}
