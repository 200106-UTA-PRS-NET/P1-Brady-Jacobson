using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;
using Domain;

namespace Storing.Repositories
{
    public class RepositoryOrder : IRepository<Orders>
    {
        PizzaDBContext pdb;
        public RepositoryOrder()
        {
            pdb = new PizzaDBContext();
        }

        public RepositoryOrder(PizzaDBContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        public Orders Addp(Orders p)
        {
            pdb.Orders.Add(p);
            pdb.SaveChanges();
            Console.WriteLine(p.OrderTime);
            var a = pdb.Orders.FirstOrDefault(d => d.OrderTime == p.OrderTime);
            return a;
        }

        public void Deletep(Orders p)
        {
            var query = from a in pdb.Orders where (a.OrderId == p.OrderId) select Mapper.MapOrder(a);
            foreach(var item in query)
            {
                pdb.Remove(item);
            }
            pdb.SaveChanges();
            return;
        }

        //TO DO: make it month based.
        public IEnumerable<Orders> Getp(Users b)
        {
            var query = from a in pdb.Orders where(a.UserId == b.UserId)
                        select Mapper.MapOrder(a);
            return query;
        }
        public IEnumerable<Orders> Getp(string u)
        {
            var query = from a in pdb.Orders
                        where (a.UserId == Convert.ToInt32(u))
                        select Mapper.MapOrder(a);
            return query;
        }
        public IEnumerable<Orders> Getp(Stores b)
        {
            var query = from a in pdb.Orders
                        where (a.StoreId == b.StoreId)
                        select Mapper.MapOrder(a);
            return query;
        }

        public IEnumerable<Orders> Getp(DateTime early, Stores st, int choice)
        {
            if (choice == 1)
            { 
                var query = from a in pdb.Orders
                            where (a.OrderTime.Day == early.Day && st.StoreId == a.StoreId)
                            select Mapper.MapOrder(a);
                return query;
            }
            else
            {
                var query = from a in pdb.Orders
                            where (a.OrderTime.Month == early.Month && st.StoreId == a.StoreId)
                            select Mapper.MapOrder(a);
                return query;
            }
        }

        public void Modifyp(Orders p)
        {
            var a = pdb.Orders.FirstOrDefault(d => d.OrderId== p.OrderId);
            a.OrderTime = DateTime.Now;
            a.PizzaAmount = p.PizzaAmount;
            a.Cost = p.Cost;
            pdb.Orders.Update(a);
            pdb.SaveChanges();
            return;
        }

        public Orders AccessP(Orders p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> Getp()
        {
            throw new NotImplementedException();
        }

        Orders IRepository<Orders>.UseIDFindStore(int p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> Getp(Orders p)
        {
            throw new NotImplementedException();
        }
    }
}
