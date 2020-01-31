using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Interfaces;
using System.Linq;
using Domain;

namespace TestPizza
{
    public class MockRepo : IRepository<Pizzas>
    {
        static IEnumerable<Domain.Models.Pizzas> pie = new List<Domain.Models.Pizzas>() {
            new Pizzas(){
            PizzaId = 1,
            OrderId = 10,
            Crust = "Original",
            Size = "16",
            PizzaCost = 10.00m
            },
            new Pizzas(){
            PizzaId = 1,
            OrderId = 10,
            Crust = "Original",
            Size = "16",
            PizzaCost = 10.00m
            }

        };

        public Pizzas AccessP(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public Pizzas Addp(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public void Deletep(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizzas> Getp()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizzas> Getp(string p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizzas> Getp(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public void Modifyp(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public Pizzas UseIDFindStore(int p)
        {
            throw new NotImplementedException();
        }
    }
}
