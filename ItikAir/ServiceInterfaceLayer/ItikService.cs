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
    public class ItikService : IItikService
    {
        ItikLogic itikLogic = new ItikLogic();
        public Penerbangan GetProduct(int id)
        {
            ItikBDO itikBDO = null;
            try
            {
                itikBDO = itikLogic.GetProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetProduct Fail!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
            }
            if (itikBDO == null)
            {
                string msg = string.Format("No fligth found for id {0}", id);
                string reason = "Empty flight!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
            }

            Penerbangan penerbangan = new Penerbangan();
            ItikBDOToPenerbanganDTO(itikBDO, penerbangan);
            return penerbangan;
        }
        public IEnumerable<Penerbangan> GetAllPenerbangan()
        {
            IEnumerable<ItikBDO> temp = null;
            try
            {
                temp = itikLogic.GetAllProduct();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetAll Fail!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
            }
            if (temp == null)
            {
                string msg = string.Format("No flight found!");
                string reason = "No flight available!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
            }
            List<Penerbangan> penerbangans = new List<Penerbangan>();
            foreach (var c in temp)
            {
                Penerbangan penerbangan = new Penerbangan();
                ItikBDOToPenerbanganDTO(c, penerbangan);
            }
            return penerbangans;
        }
        public void InsertProduct(Penerbangan penerbangan)
        {
            try
            {
                ItikBDO itikBDO = PenerbanganDTOToItikBDO(penerbangan);
                Console.WriteLine(itikBDO.Penerbangan_ID);

                itikLogic.InsertProduct(itikBDO);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Insert Fail!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
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
                    ItikBDO itikBDO = PenerbanganDTOToItikBDO(penerbangan);
                    result = itikLogic.UpdatedProduct(ref itikBDO, ref message);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw new FaultException<ItikFault>
                     (new ItikFault(msg), msg);
                }
            }
            return result;
        }

        public void DeleteProduct(int id)
        {
            try
            {
                itikLogic.DeleteProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Delete Fail!";
                throw new FaultException<ItikFault>(new ItikFault(msg), reason);
            }
        }

        public void ItikBDOToPenerbanganDTO(ItikBDO itikBDO, Penerbangan penerbangan)
        {
            penerbangan.penerbanganID = itikBDO.Penerbangan_ID;
            penerbangan.pesawat = itikBDO.Pesawat;
            penerbangan.jlhKursi = itikBDO.Jlh_Kursi;
            penerbangan.harga = itikBDO.Harga;
            penerbangan.asal = itikBDO.Asal;
            penerbangan.tujuan = itikBDO.Tujuan;
            penerbangan.terbang = itikBDO.Terbang;
        }

        public ItikBDO PenerbanganDTOToItikBDO(Penerbangan penerbangan)
        {
            ItikBDO itikBDO = new ItikBDO();
            itikBDO.Penerbangan_ID = penerbangan.penerbanganID;
            itikBDO.Pesawat = penerbangan.pesawat;
            itikBDO.Jlh_Kursi = (int)penerbangan.jlhKursi;
            itikBDO.Harga = (int)penerbangan.harga;
            itikBDO.Asal = penerbangan.asal;
            itikBDO.Tujuan = penerbangan.tujuan;
            itikBDO.Terbang = (DateTime)penerbangan.terbang;
            System.Diagnostics.Debug.WriteLine(itikBDO.Penerbangan_ID);

            return itikBDO;
        }
    }
}
