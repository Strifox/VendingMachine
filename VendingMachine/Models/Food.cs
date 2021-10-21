using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models
{
    public class Food : Product
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName">Set the product name</param>
        /// <param name="price">Set the food price</param>
        /// <param name="message">Message how to use the item</param>
        public Food(string productName, decimal price,  string message)
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
