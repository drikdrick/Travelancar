using BusinessDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PuyuhLogic
    {
        PuyuhBDO puyuhBDO = new PuyuhBDO();

        public PuyuhBDO GetProduct(int id)
        {
            return puyuhBDO.GetProduct(id);
        }

        public bool UpdatedProduct(ref PuyuhBDO puyuhBDO, ref string message)
        {
            var productInDB = GetProduct(puyuhBDO.Penerbangan_ID);
            if (puyuhBDO == null)
            {
                message = "Can't get flight with this ID";
                return false;
            }
            else
            {
                return puyuhBDO.UpdateProduct(ref puyuhBDO, ref message);
            }
        }

        public IEnumerable<PuyuhBDO> GetAllProduct()
        {
            return puyuhBDO.GetAllProduct();
        }

        public void InsertProduct(PuyuhBDO puyuh)
        {
            puyuhBDO.InsertProduct(puyuh);
        }

        public void DeleteProduct(int id)
        {
            puyuhBDO.DeleteProduct(id);
        }
    }
}
