using System;
using System.Collections.Generic;

namespace LinqTasks
{
    internal class Buyer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public int ReleaseDate { get; internal set; }
        public int DateTime { get; internal set; }
        public object Model { get; internal set; }
    }

    internal class Car
    {
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Buyer Buyer { get; set; }
    }

    internal struct Address
    {
        public string Street { get; set; }

        public int Building { get; set; }
    }
}
