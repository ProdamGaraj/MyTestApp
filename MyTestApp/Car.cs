using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp
{
    public class Car
    {
        public string Model { get; }

        public decimal Price { get; }

        public Car(string model, decimal price)
        {
            Model = model;
            Price = price;
        }
    }
}
