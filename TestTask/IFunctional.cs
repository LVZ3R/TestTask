using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    interface IFunctional
    {
        void Add<T> (T value, List<T> listToAdd);
        void Print<T> (List<T> listToPrint);
        void Remove<T> (List<T> listToRemove, int index);
        void Edit(int sender, int index);
        void FindByParams();
        void FindByID(int id);
    }
}
