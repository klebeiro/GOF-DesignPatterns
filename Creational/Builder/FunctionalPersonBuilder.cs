﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.Functional
{
    public class Person
    {
        public string Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
        public TSelf Do(Action<Person> action) => AddAction(action);
        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    /*
    public sealed class PersonBuilder
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
        public PersonBuilder Do(Action<Person> action) => AddAction(action);
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
        private PersonBuilder AddAction(Action<Person> action)
        {
            actions.Add(p => { action(p);
                return p;
            });
            return this;
        }

        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
    }
    */

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }

    /*
    static class Program
    {
        public static void Main(string[] args)
        {
            var person = new PersonBuilder().Called("Klebeiro").WorksAs("SWE").Build();
        }
    }
    */
}
