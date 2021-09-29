using System;
using System.Collections.Generic;

namespace LinqTasks
{
    internal class Initializer
    {
        public static IEnumerable<Buyer> GenerateData()
        {
            yield return
                new BuyerBuilder("Bill", "Gates", 1000_000, "1-st Street", 10)
                    .AddCar("BMW", 120_000, "01-01-2020")
                    .AddCar("Mercedes", 220_000, "01-01-2021")
                    .AddCar("Lada", 300, "01-01-1985")
                    .Build();

            yield return
                new BuyerBuilder("John", "Cena", 10_000, "2-st Street", 13)
                    .AddCar("BMW", 40_000, "01-01-2018")
                    .Build();

            yield return
                new BuyerBuilder("Linus", "Torvalds", 1000, "3-st Street", 65)
                    .Build();

            yield break;
        }
    }

    internal class BuyerBuilder
    {
        private readonly Buyer buyer;
        private readonly List<Car> cars = new List<Car>();

        public BuyerBuilder(string firstName, string lastName, int salary, string street, int building)
        {
            buyer = new Buyer
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary,
                Address = new Address
                {
                    Street = street,
                    Building = building
                }
            };
        }

        public BuyerBuilder AddCar(string model, int price, string releaseDate)
        {
            cars.Add(new Car
            {
                Model = model,
                Price = price,
                ReleaseDate = DateTime.Parse(releaseDate),
                Buyer = buyer
            });

            return this;
        }

        public Buyer Build()
        {
            buyer.Cars = cars;
            return buyer;
        }
    }
}
