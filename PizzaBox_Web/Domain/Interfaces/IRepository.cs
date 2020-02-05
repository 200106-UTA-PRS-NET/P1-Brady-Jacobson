using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Addp(T p);
        void Deletep(T p);
        void Modifyp(T p);
        IEnumerable<T> Getp(string temp);
        IEnumerable<T> Getp();

        IEnumerable<T> Getp(T p);
        T UseIDFindStore(int p);

        T AccessP(T p);
    }
}
