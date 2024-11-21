using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingDemo_13Nov
{
    internal class Products
    {
        public int Prodid { get; set; }
        public string ProdName { get; set; }
        public int Price { get; set; }
    }


    internal class ProductUtility
    {

        public Products FindProduct(int id) {
            Products prod=Program.productList.Find(p=>p.Prodid==id);
            if (prod == null)
            {
                throw new ProductNotFoundException("This product doesn't exist");

            }
            else
            {
                return prod;
            }
        }
            

    }

    [Serializable]
    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
        {
        }

        public ProductNotFoundException(string message) : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
