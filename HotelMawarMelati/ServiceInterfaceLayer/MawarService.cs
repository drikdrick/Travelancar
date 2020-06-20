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
    public class MawarService : IMawarService
    {
        MawarLogic mawarLogic = new MawarLogic();
        public Kamar GetProduct(int id)
        {
            MawarDBO mawarDBO = null;
            try
            {
                mawarDBO = mawarLogic.GetProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetProduct Fail!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
            }
            if (mawarDBO == null)
            {
                string msg = string.Format("No room found for id {0}", id);
                string reason = "Empty room!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
            }

            Kamar kamar = new Kamar();
            MawarBDOToPenerbanganDTO(mawarDBO, kamar);
            return kamar;
        }

        public IEnumerable<Kamar> GetAllPenerbangan()
        {
            IEnumerable<MawarDBO> temp = null;
            try
            {
                temp = mawarLogic.GetAllProduct();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "GetAll Fail!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
            }
            if (temp == null)
            {
                string msg = string.Format("No room found!");
                string reason = "No room available!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
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
                MawarDBO mawarDBO = KamarDTOToMawarBDO(kamar);

                mawarLogic.InsertProduct(mawarDBO);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Insert Fail!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
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
                    MawarDBO mawarDBO = KamarDTOToMawarBDO(kamar);
                    result = mawarLogic.UpdatedProduct(ref mawarDBO, ref message);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw new FaultException<MawarFault>
                     (new MawarFault(msg), msg);
                }
            }
            return result;
        }

        public void DeleteProduct(int id)
        {
            try
            {
                mawarLogic.DeleteProduct(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string reason = "Delete Fail!";
                throw new FaultException<MawarFault>(new MawarFault(msg), reason);
            }
        }

        public void MawarBDOToPenerbanganDTO(MawarDBO mawarDBO, Kamar kamar)
        {
            kamar.kamar_Id = mawarDBO.Kamar_ID;
            kamar.jumlah = (int)mawarDBO.Jumlah;
            kamar.harga = (int)mawarDBO.Harga;
            kamar.jenis = mawarDBO.Jenis;
        }

        public MawarDBO KamarDTOToMawarBDO(Kamar kamar)
        {
            MawarDBO mawarDBO = new MawarDBO();
            mawarDBO.Kamar_ID = kamar.kamar_Id;
            mawarDBO.Jenis = kamar.jenis;
            mawarDBO.Harga = (int)kamar.harga;
            mawarDBO.Jumlah = (int)kamar.jumlah;

            return mawarDBO;
        }
    }
}
