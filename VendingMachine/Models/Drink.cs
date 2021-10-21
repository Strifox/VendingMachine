using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models
{
    public class Drink : Product
    {
        public Drink(string productName, decimal price,  string message)
        {
            ProductName = productName;
            Price = price;
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
