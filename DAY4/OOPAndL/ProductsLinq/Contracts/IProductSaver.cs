using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsLinq.Contracts
{
    public interface IProductSaver
    {
        void SaveProducts(List<Product> products);
        List<Product> LoadProduct();
    }
}
