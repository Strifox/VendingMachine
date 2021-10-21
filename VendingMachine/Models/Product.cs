using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models
{
    public abstract class Product
    {
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Products price and info
        /// </summary>
        public virtual string Examine()
        {
            return $"Product: {ProductName}\tPrice: {Price}";
        }

        /// <summary>
        /// Tells the customer how to use the product
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Message explaining how to use it</returns>
        public virtual string Use()
        {
            return Message;
        }
    }
}
