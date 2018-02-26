using System.ComponentModel;

namespace Evolent.Application
{
    public class BootStrapper
    {
        public static void Execute(IContainer container)
        {
            container.RegisterType<IEvolentRepositoryFactory, EvolentRepositoryFactory>();
        }
    }
}
