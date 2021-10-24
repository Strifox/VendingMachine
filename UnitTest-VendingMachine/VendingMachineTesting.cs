using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Models;
using Xunit;

namespace UnitTest_VendingMachine
{
    public class VendingMachineTesting
    {
        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        [InlineData(500)]
        public void InsertMoneyTest(decimal insertMoney)
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();

            var expected = vendingMachine.InsertMoney(insertMoney).ToArray().Sum();

            Assert.Equal(expected, insertMoney);
        }

        [Theory]
        [InlineData(55)]
        [InlineData(200)]
        [InlineData(5000)]
        public void InsertMoneyExceptionTest(decimal insertMoney)
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();

            var result = Assert.Throws<Exception>(() => vendingMachine.InsertMoney(insertMoney));
            var expected = "You can only insert one of the denominations";

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PurchaseTest()
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();
            vendingMachine.InsertMoney(500);

            Food tacos = new Food("Tacos", 49, "Wrap the bread and eat it");
            Drink fanta = new Drink("Fanta", 20, "Drink the fanta");
            Toy waterPistol = new Toy("Water Pistol", 205, "Fill it with water and shoot");

            vendingMachine.Purchase(tacos);
            vendingMachine.Purchase(fanta);
            vendingMachine.Purchase(waterPistol);

            var expectedAmountOfProducts = 3;

            Assert.NotNull(vendingMachine.PurchasedProducts);
            Assert.Equal( expectedAmountOfProducts, vendingMachine.PurchasedProducts.Count);
        }

        [Fact]
        public void ShowAllProductsTest()
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();

            Food tacos = new Food("Tacos", 49, "Wrap the bread and eat it");
            Drink fanta = new Drink("Fanta", 20, "Drink the fanta");
            Toy waterPistol = new Toy("Water Pistol", 205, "Fill it with water and shoot");

            vendingMachine.Products.Add(tacos);
            vendingMachine.Products.Add(fanta);
            vendingMachine.Products.Add(waterPistol);

            var expectedAmountOfProducts = 3;

            Assert.Equal(expectedAmountOfProducts, vendingMachine.Products.Count);
        }

        [Fact]
        public void TotalCostTest()
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();

            Food tacos = new Food("Tacos", 49, "Wrap the bread and eat it");
            Drink fanta = new Drink("Fanta", 20, "Drink the fanta");
            Toy waterPistol = new Toy("Water Pistol", 205, "Fill it with water and shoot");

            vendingMachine.InsertMoney(500);

            vendingMachine.Purchase(tacos);
            vendingMachine.Purchase(fanta);
            vendingMachine.Purchase(waterPistol);

            var expected = tacos.Price + fanta.Price + waterPistol.Price;
            vendingMachine.TotalCostCalculation();

            Assert.Equal(expected, vendingMachine.TotalCost);

        }

        [Fact]
        public void ExchangeTest()
        {
            AllAroundVendingMachine vendingMachine = new AllAroundVendingMachine();

            Food tacos = new Food("Tacos", 49, "Wrap the bread and eat it");
            Drink fanta = new Drink("Fanta", 20, "Drink the fanta");
            Toy waterPistol = new Toy("Water Pistol", 205, "Fill it with water and shoot");

            vendingMachine.InsertMoney(500);

            vendingMachine.Purchase(tacos);
            vendingMachine.Purchase(fanta);
            vendingMachine.Purchase(waterPistol);

            var expected = 500 - (tacos.Price + fanta.Price + waterPistol.Price);

            vendingMachine.EndTransaction();

            Assert.Equal(expected, vendingMachine.Exchange);

        }

    }
}
