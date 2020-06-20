using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessDomainObject;

namespace BusinessLogic
{
    public class PinguinLogic
    {
        PinguinBDO pinguinBDO = new PinguinBDO();

        public PinguinBDO GetProduct(int id)
        {
            return pinguinBDO.GetProduct(id);
        }

        public bool UpdatedProduct(ref PinguinBDO pinguinBDO, ref string message)
        {
            var productInDB = GetProduct(pinguinBDO.Penerbangan_ID);
            if (pinguinBDO == null)
            {
                message = "Can't get flight with this ID";
                return false;
            }
            else
            {
                return pinguinBDO.UpdateProduct(ref pinguinBDO, ref message);
            }
        }

        public IEnumerable<PinguinBDO> GetAllProduct()
        {
            return pinguinBDO.GetAllProduct();
        }

        public void InsertProduct(PinguinBDO pinguin)
        {
            pinguinBDO.InsertProduct(pinguin);
        }

        public void DeleteProduct(int id)
        {
            pinguinBDO.DeleteProduct(id);
        }
    }
}
