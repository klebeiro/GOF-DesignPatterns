using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.Faceted
{
    public class Person
    {
        // adress
        public string StreetAdress, PostCode, City;
        // employment
        public string CompanyName, Position;
        public int AnnualIncome;
    }

    public class PersonBuilder // facade
    {
        // reference!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        // might not work with a value type!
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAdress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                    .At("123 Redmond Road")
                    .In("Redmond")
                    .WithPostCode("SW12AC")
                .Works
                    .At("Microsoft")
                    .AsA("SWE")
                    .Earning(120000);
        }
    }
    */
}
