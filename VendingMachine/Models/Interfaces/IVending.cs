using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models.Interfaces
{
    interface IVending
    {
        void Purchase(Product product);
        List<Product> ShowAll();
        List<decimal> InsertMoney(decimal insertedMoney);
        void EndTransaction();
    }
}
