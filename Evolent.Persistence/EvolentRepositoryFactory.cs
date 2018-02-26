using Evolent.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Persistence
{
    public class EvolentRepositoryFactory : IEvolentRepositoryFactory
    {
        public IEvolentRepository Create()
        {
            return new EvolentRepository();
        }
    }
}
