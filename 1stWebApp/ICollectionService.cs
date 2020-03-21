using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp
{
    public interface ICollectionService<T>
    {
        void add(T elem);
        void remove(T elem);
        string view(T elem);
    }
}
