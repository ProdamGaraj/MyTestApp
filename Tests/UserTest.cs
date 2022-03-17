using System;
using MyTestApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UserTest
    {
        [SetUp]
        public void SetupValues()
        {
            TestContext.Progress.WriteLine("SetUp");
        }

        [TearDown]
        public void CleanValues()
        {
            TestContext.Progress.WriteLine("TearDown");
        }

        [Test]
        [TestCase(0, 0, -1000)]
        [TestCase(0, 0, 0)]
        public void DepositTest(decimal currentUserBalance, decimal destinationUserBalance, decimal deposit)
        {
            //Arrange
            User user = new User();
            User destination = new User();
            //Act
            user.Deposit(currentUserBalance);
            destination.Deposit(destinationUserBalance);
            //Assert
            Assert.AreEqual(user.GetBalance(), destination.GetBalance());
        }

        [Test]
        [TestCase(10000, 4000, 6000)]
        public void PurchaseTest(decimal currentUserBalance, decimal destinationUserBalance, decimal price)
        {
            //Arrange
            User user = new User();
            user.Deposit(currentUserBalance);
            User destination= new User();
            destination.Deposit(destinationUserBalance);
            //Act
            user.Purchase(price);
            //Assert
            Assert.AreEqual(currentUserBalance - price, destination.GetBalance());
            Assert.AreEqual(destinationUserBalance, user.GetBalance());
        }
        [Test]
        [TestCase(10000, 15000, 5000)]
        public void SellTest(decimal currentUserBalance, decimal destinationUserBalance, decimal price)
        {
            //Arrange
            User user = new User();
            user.Deposit(currentUserBalance);
            Car car = user.PutUpForSale("BMW", price);
            User destination = new User();
            destination.Deposit(destinationUserBalance);
            //Act
            user.Sale(car);
            //Assert
            Assert.AreEqual(destinationUserBalance, user.GetBalance());
            Assert.AreEqual(currentUserBalance + price, destination.GetBalance());
        }

        [Test]
        [TestCase]
        public void PutUpOnSaleTest()
        {
            //Arrange
            User user = new User();
            //Act
            Car car = user.PutUpForSale("BMW", 15000);
            //Assert
            Assert.IsNotNull(car);
        }
    }
}
