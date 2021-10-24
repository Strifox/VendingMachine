using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models.Interfaces;

namespace VendingMachine.Models
{
    public class AllAroundVendingMachine : IVending
    {
        public readonly int[] MoneyDenomination = new int[8] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public List<decimal> MoneyPool = new List<decimal>();
        public List<Product> Products = new List<Product>();
        public List<Product> PurchasedProducts = new List<Product>();

        public decimal Exchange { get; set; }
        public decimal TotalCost { get; set; }

        public void EndTransaction()
        {
            TotalCostCalculation();
            ExchangeCalculation();

            foreach (var product in PurchasedProducts)
            {
                Console.WriteLine($"You bought {product.ProductName} for {product.Price}.\nHow to use it: {product.Use()}" +
                    $"\nYou got {Exchange}kr in exchange.");
            }

            Console.WriteLine($"Total cost for all products: {TotalCost}");
        }

        public List<decimal> InsertMoney(decimal insertedMoney)
        {
            if (Array.Exists(MoneyDenomination, x => x == insertedMoney))
                MoneyPool.Add(insertedMoney);
            else
                throw new Exception("You can only insert one of the denominations");

            return MoneyPool;
        }

        public void Purchase(Product product)
        {
            if (MoneyPool.ToArray().Sum() < product.Price)
                throw new Exception("Not enough money");

            PurchasedProducts.Add(product);
        }

        public List<Product> ShowAll()
        {
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.ProductName}\n{product.Price}\n\t- {product.Message}\n");
            }

            return Products;
        }

        public void TotalCostCalculation()
        {
            foreach (var product in PurchasedProducts)
            {
                TotalCost += product.Price;
            }
        }

        public void ExchangeCalculation()
        {
            Exchange = MoneyPool.Sum() - TotalCost;
        }
    }
}
