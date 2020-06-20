using BusinessDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class KasurLogic
    {
        KasurEmpukBDO kasurBDO = new KasurEmpukBDO();

        public KasurEmpukBDO GetProduct(int id)
        {
            return kasurBDO.GetProduct(id);
        }

        public bool UpdatedProduct(ref KasurEmpukBDO kasurBDO, ref string message)
        {
            var productInDB = GetProduct(kasurBDO.Kamar_ID);
            if (kasurBDO == null)
            {
                message = "Can't get flight with this ID";
                return false;
            }
            else
            {
                return kasurBDO.UpdateProduct(ref kasurBDO, ref message);
            }
        }

        public IEnumerable<KasurEmpukBDO> GetAllProduct()
        {
            return kasurBDO.GetAllProduct();
        }

        public void InsertProduct(KasurEmpukBDO mawar)
        {
            kasurBDO.InsertProduct(mawar);
        }

        public void DeleteProduct(int id)
        {
            kasurBDO.DeleteProduct(id);
        }
    }
}
