using Evolent.Application;
using Evolent.Application.Contract;
using Unity;

namespace Evolent.Service
{
    public class BootStrapper
    {
        public static void Execute(UnityContainer container)
        {
            container.RegisterType<IEvolentApplicationService, EvolentApplicationService>();
            Application.BootStrapper.Execute(container);
        }
    }
}