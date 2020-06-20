using BusinessDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ItikLogic
    {
        ItikBDO itikBDO = new ItikBDO();

        public ItikBDO GetProduct(int id)
        {
            return itikBDO.GetProduct(id);
        }

        public bool UpdatedProduct(ref ItikBDO itikBDO, ref string message)
        {
            var productInDB = GetProduct(itikBDO.Penerbangan_ID);
            if (itikBDO == null)
            {
                message = "Can't get flight with this ID";
                return false;
            }
            else
            {
                return itikBDO.UpdateProduct(ref itikBDO, ref message);
            }
        }

        public IEnumerable<ItikBDO> GetAllProduct()
        {
            return itikBDO.GetAllProduct();
        }

        public void InsertProduct(ItikBDO itik)
        {
            itikBDO.InsertProduct(itik);
        }

        public void DeleteProduct(int id)
        {
            itikBDO.DeleteProduct(id);
        }
    }
}
