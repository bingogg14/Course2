using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Logic
{
    public static class LogicDependencyResolver
    {
        public static IUnitOfWork ResolveUoW()
        {
            return new UnitOfWork();
        }
    }
}
