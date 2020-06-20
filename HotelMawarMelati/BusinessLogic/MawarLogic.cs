using BusinessDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MawarLogic
    {
        MawarDBO mawarDBO = new MawarDBO();

        public MawarDBO GetProduct(int id)
        {
            return mawarDBO.GetProduct(id);
        }

        public bool UpdatedProduct(ref MawarDBO mawarDBO, ref string message)
        {
            var productInDB = GetProduct(mawarDBO.Kamar_ID);
            if (mawarDBO == null)
            {
                message = "Can't get flight with this ID";
                return false;
            }
            else
            {
                return mawarDBO.UpdateProduct(ref mawarDBO, ref message);
            }
        }

        public IEnumerable<MawarDBO> GetAllProduct()
        {
            return mawarDBO.GetAllProduct();
        }

        public void InsertProduct(MawarDBO mawar)
        {
            mawarDBO.InsertProduct(mawar);
        }

        public void DeleteProduct(int id)
        {
            mawarDBO.DeleteProduct(id);
        }
    }
}
