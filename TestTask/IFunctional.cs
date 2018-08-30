using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    interface IFunctional
    {
        void Add(object value);
        void Print(int sender);
        void Remove(int sender, int index);
        void Edit(int sender, int index);
        void FindByParams();
        void FindByID(int id);
    }
}
