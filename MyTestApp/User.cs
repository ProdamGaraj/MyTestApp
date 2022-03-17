using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp
{
    public class User
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            if (amount>0)
            {
                balance += amount;
            }  
        }

        public void Purchase(decimal price)
        {
            if (balance >= price)
            {
                balance -= price;
            }
            else
            {
                throw new Exception("Not enough money on your balance");
            } 
        }

        public Car PutUpForSale(string model, decimal price)
        {
            return new Car(model, price);
        }

        public void Sale(Car car)
        {
            Deposit(car.Price);
        }
        public decimal GetBalance()
        {
            return balance;
        }
    }
}
