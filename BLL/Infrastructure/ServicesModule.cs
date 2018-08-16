using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ServicesModule : NinjectModule
    {
        private string _connection;

        public ServicesModule(string connection)
        {
            _connection = connection;
        }
        public override void Load()
        {
            Bind<DAL.Interfaces.IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connection);
        }
    }
}
