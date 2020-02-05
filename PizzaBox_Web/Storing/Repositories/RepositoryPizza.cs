﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Interfaces;
using System.Linq;
using Domain;

namespace Storing.Repositories
{
    public class RepositoryPizza : IRepository<Pizzas>
    {
        PizzaDBContext pdb;
        public RepositoryPizza()
        {
            pdb = new PizzaDBContext();
        }
        public RepositoryPizza(PizzaDBContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        public Pizzas AccessP(Pizzas p)
        {
            var aa = pdb.Pizzas.OrderByDescending(d => d.PizzaId);
            var a = aa.FirstOrDefault(d => d.OrderId == p.OrderId);
            return a;
        }

        public Pizzas Addp(Pizzas p)
        {
            pdb.Pizzas.Add(p);
            pdb.SaveChanges();
            return p;
        }

        public void Deletep(Pizzas p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizzas> Getp()
        {
            var query = from p in pdb.Pizzas
                        select Mapper.MapPizza(p);
            return query;
        }

        public IEnumerable<Pizzas> Getp(string p)
        {
            var query = from a in pdb.Pizzas
                        where (a.OrderId.ToString() == p)
                        select Mapper.MapPizza(a);
            return query;
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
