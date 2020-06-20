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
    public class PuyuhService : IPuyuhService
    {
        PuyuhLogic pinguinLogic = new PuyuhLogic();
        public Penerbangan GetProduct(int id)
        {
            PuyuhBDO puyuhBDO = null;
            try
            {
                puyuhBDO = pinguinLogic.GetProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetProduct Fail!";
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
            }
            if (puyuhBDO == null)
            {
                string msg = string.Format("No fligth found for id {0}", id);
                string reason = "Empty flight!";
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
            }

            Penerbangan penerbangan = new Penerbangan();
            PinguinBDOToPenerbanganDTO(puyuhBDO, penerbangan);
            return penerbangan;
        }

        public IEnumerable<Penerbangan> GetAllPenerbangan()
        {
            IEnumerable<PuyuhBDO> temp = null;
            try
            {
                temp = pinguinLogic.GetAllProduct();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetAll Fail!";
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
            }
            if (temp == null)
            {
                string msg = string.Format("No flight found!");
                string reason = "No flight available!";
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
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
                PuyuhBDO puyuhBDO = PenerbanganDTOToPinguinBDO(penerbangan);
                Console.WriteLine(puyuhBDO.Penerbangan_ID);

                pinguinLogic.InsertProduct(puyuhBDO);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Insert Fail!";
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
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
                    PuyuhBDO puyuhBDO = PenerbanganDTOToPinguinBDO(penerbangan);
                    result = pinguinLogic.UpdatedProduct(ref puyuhBDO, ref message);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw new FaultException<PuyuhFault>
                     (new PuyuhFault(msg), msg);
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
                throw new FaultException<PuyuhFault>(new PuyuhFault(msg), reason);
            }
        }

        public void PinguinBDOToPenerbanganDTO(PuyuhBDO puyuhBDO, Penerbangan penerbangan)
        {
            penerbangan.penerbanganID = puyuhBDO.Penerbangan_ID;
            penerbangan.pesawat = puyuhBDO.Pesawat;
            penerbangan.jlhKursi = puyuhBDO.Jlh_Kursi;
            penerbangan.harga = puyuhBDO.Harga;
            penerbangan.asal = puyuhBDO.Asal;
            penerbangan.tujuan = puyuhBDO.Tujuan;
            penerbangan.terbang = puyuhBDO.Terbang;
        }

        public PuyuhBDO PenerbanganDTOToPinguinBDO(Penerbangan penerbangan)
        {
            PuyuhBDO puyuhBDO = new PuyuhBDO();
            puyuhBDO.Penerbangan_ID = penerbangan.penerbanganID;
            puyuhBDO.Pesawat = penerbangan.pesawat;
            puyuhBDO.Jlh_Kursi = (int)penerbangan.jlhKursi;
            puyuhBDO.Harga = (int)penerbangan.harga;
            puyuhBDO.Asal = penerbangan.asal;
            puyuhBDO.Tujuan = penerbangan.tujuan;
            puyuhBDO.Terbang = (DateTime)penerbangan.terbang;
            System.Diagnostics.Debug.WriteLine(puyuhBDO.Penerbangan_ID);

            return puyuhBDO;
        }
    }
}
