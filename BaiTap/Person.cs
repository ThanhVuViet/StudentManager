using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaiTap
{
    internal class Person
    {
        private static int autoIncrementId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Person(int id, string name, DateTime dateOfBirth, string address, double height, double weight)
        {
            this.Id = autoIncrementId++;
            if (string.IsNullOrEmpty(name) || name.Length > 100)
                throw new ArgumentException("Name must be non-empty and less than 100 characters.");
            this.Name = name;
            if (dateOfBirth.Year < 1900)
                throw new ArgumentException("Birth date must be after the year 1900.");
            DateOfBirth = dateOfBirth;
            if (string.IsNullOrEmpty(address) || address.Length > 300)
                throw new ArgumentException("Address must be non-empty and less than 300 characters.");
            Address = address;
            if (height < 50.0 || height > 300.0)
                throw new ArgumentException("Height must be between 50.0 cm and 300.0 cm.");
            Height = height;
            if (weight < 5.0 || weight > 1000.0)
                throw new ArgumentException("Weight must be between 5.0 kg and 1000.0 kg.");
            Weight = weight;
        }
        public Person() { }
        public override string ToString()
        {
            return $"Person [ID={Id}, Name={Name}, BirthDate={DateOfBirth.ToShortDateString()}, Address={Address}, Height={Height} cm, Weight={Weight} kg]";
        }

    }
}
