using System;
using VendingMachine.Models;
using Xunit;

namespace UnitTest_VendingMachine
{
    public class ModelsTesting
    {
        readonly Food tacos = new Food("Tacos", 49, "Wrap the bread and eat it");
        readonly Drink fanta = new Drink("Fanta", 20, "Drink the fanta");
        readonly Toy waterPistol = new Toy("Water Pistol", 205, "Fill it with water and shoot");

        [Fact]
        public void TestPrices()
        {
            var expectedTacosPrice = 49;
            var expectedFantaPrice = 20;
            var expectedWaterPistolPrice = 205;

            Assert.Equal(expectedTacosPrice, tacos.Price);
            Assert.Equal(expectedFantaPrice, fanta.Price);
            Assert.Equal(expectedWaterPistolPrice, waterPistol.Price);
        }

        [Fact]
        public void TestMessages()
        {
            Assert.Equal(tacos.Use(), tacos.Message);
            Assert.Equal(fanta.Use(), fanta.Message);
            Assert.Equal(waterPistol.Use(), waterPistol.Message);
        }

        [Fact]
        public void TestProductName()
        {
            Assert.Equal("Tacos", tacos.ProductName);
            Assert.Equal("Fanta", fanta.ProductName);
            Assert.Equal("Water Pistol", waterPistol.ProductName);
        }

        [Fact]
        public void TestExamineMethod()
        {
            Assert.Equal($"Product: {tacos.ProductName}\tPrice: {tacos.Price}", tacos.Examine());
            Assert.Equal($"Product: {fanta.ProductName}\tPrice: {fanta.Price}", fanta.Examine());
            Assert.Equal($"Product: {waterPistol.ProductName}\tPrice: {waterPistol.Price}", waterPistol.Examine());
        }
    }
}
