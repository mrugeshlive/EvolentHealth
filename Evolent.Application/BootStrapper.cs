using AutoMapper;
using Evolent.Application.EntityMappers;
using Evolent.DomainModel;
using Evolent.Persistence;
using Unity;

namespace Evolent.Application
{
    public class BootStrapper
    {
        public static void Execute(UnityContainer container)
        {
            container.RegisterType<IEvolentRepositoryFactory, EvolentRepositoryFactory>();
            Mapper.Initialize(cfg => { cfg.AddProfile<ResponseProfile>(); });
        }
    }
}
