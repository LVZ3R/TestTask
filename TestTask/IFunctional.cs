using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    interface IFunctional<T>
    {
        void Add(object value);
        void Edit(int index, List<T> listToEdit);
        void Remove(int index, List<T> listToRemove);
        void Print(T value, List<T> listToPrint);
    }
}
