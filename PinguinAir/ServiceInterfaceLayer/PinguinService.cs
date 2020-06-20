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
    public class PinguinService : IPinguinService
    {
        PinguinLogic pinguinLogic = new PinguinLogic();
        public Penerbangan GetProduct(int id)
        {
            PinguinBDO pinguinBDO = null;
            try
            {
                pinguinBDO = pinguinLogic.GetProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetProduct Fail!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }
            if (pinguinBDO == null)
            {
                string msg = string.Format("No fligth found for id {0}", id);
                string reason = "Empty flight!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }

            Penerbangan penerbangan = new Penerbangan();
            PinguinBDOToPenerbanganDTO(pinguinBDO, penerbangan);
            return penerbangan;
        }
        public IEnumerable<Penerbangan> GetAllPenerbangan()
        {
            IEnumerable<PinguinBDO> temp = null;
            try
            {
                temp = pinguinLogic.GetAllProduct();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetAll Fail!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }
            if (temp == null)
            {
                string msg = string.Format("No flight found!");
                string reason = "No flight available!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }
            List<Penerbangan> penerbangans = new List<Penerbangan>();
            foreach (var c in temp)
            {
                Penerbangan penerbangan = new Penerbangan();
                PinguinBDOToPenerbanganDTO(c, penerbangan);
            }
            return penerbangans;
        }
        public void InsertProduct(Penerbangan penerbangan)
        {
            try
            {
                PinguinBDO pinguinBDO = PenerbanganDTOToPinguinBDO(penerbangan);
                Console.WriteLine(pinguinBDO.Penerbangan_ID);

                pinguinLogic.InsertProduct(pinguinBDO);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Insert Fail!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }
        }
        public bool UpdateProduct(ref Penerbangan penerbangan, ref string message)
        {
            bool result = true;
            if (penerbangan.harga <= 0)
            {
                message = "Price cannot be <=0";
                result = false;
            }
            else if (penerbangan.jlhKursi <= 0)
            {
                message = "Total seat cannot be <=0";
                result = false;
            }
            else if (string.IsNullOrEmpty(penerbangan.pesawat))
            {
                message = "Plane's name cannot be empty";
                result = false;
            }
            else if (string.IsNullOrEmpty(penerbangan.asal))
            {
                message = "Departure cannot be empty";
                result = false;
            }
            else if (string.IsNullOrEmpty(penerbangan.tujuan))
            {
                message = "Arrived cannot be empty";
                result = false;
            }
            else
            {
                try
                {
                    PinguinBDO pinguinBDO = PenerbanganDTOToPinguinBDO(penerbangan);
                    result = pinguinLogic.UpdatedProduct(ref pinguinBDO, ref message);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw new FaultException<PinguinFault>
                     (new PinguinFault(msg), msg);
                }
            }
            return result;
        }

        public void DeleteProduct(int id)
        {
            try
            {
                pinguinLogic.DeleteProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Delete Fail!";
                throw new FaultException<PinguinFault>(new PinguinFault(msg), reason);
            }
        }

        public void PinguinBDOToPenerbanganDTO(PinguinBDO pinguinBDO, Penerbangan penerbangan)
        {
            penerbangan.penerbanganID = pinguinBDO.Penerbangan_ID;
            penerbangan.pesawat = pinguinBDO.Pesawat;
            penerbangan.jlhKursi = pinguinBDO.Jlh_Kursi;
            penerbangan.harga = pinguinBDO.Harga;
            penerbangan.asal = pinguinBDO.Asal;
            penerbangan.tujuan = pinguinBDO.Tujuan;
            penerbangan.terbang = pinguinBDO.Terbang;
        }

        public PinguinBDO PenerbanganDTOToPinguinBDO(Penerbangan penerbangan)
        {
            PinguinBDO pinguinBDO = new PinguinBDO();
            pinguinBDO.Penerbangan_ID = penerbangan.penerbanganID;
            pinguinBDO.Pesawat = penerbangan.pesawat;
            pinguinBDO.Jlh_Kursi = (int)penerbangan.jlhKursi;
            pinguinBDO.Harga = (int)penerbangan.harga;
            pinguinBDO.Asal = penerbangan.asal;
            pinguinBDO.Tujuan = penerbangan.tujuan;
            pinguinBDO.Terbang = (DateTime)penerbangan.terbang;
            System.Diagnostics.Debug.WriteLine(pinguinBDO.Penerbangan_ID);

            return pinguinBDO;
        }
    }
}
