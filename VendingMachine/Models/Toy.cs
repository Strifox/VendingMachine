using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models
{
    public class Toy : Product
    {
        public Toy(string productName, decimal price, string message)
        {
            Price = price;
            ProductName = productName;
            Message = message;
        }

        /// <summary>
        /// Tells the user how to use the object
        /// </summary>
        /// <returns></returns>
        public override string Use()
        {
            return Message;
        }
    }
}
