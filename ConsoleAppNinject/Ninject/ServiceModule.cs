using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppNinject.Core.Interfaces.Data;
using ConsoleAppNinject.Core.Interfaces.Service;
using ConsoleAppNinject.Data;
using ConsoleAppNinject.Service;
using Ninject.Modules;

namespace ConsoleAppNinject.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            Bind<IDatabaseFactory>().To<DatabaseFactory>().InThreadScope();
            Bind<IPersonRepository>().To<PersonRepository>().InThreadScope();
            Bind<IPersonService>().To<PersonService>().InThreadScope();
        }
    }
}
