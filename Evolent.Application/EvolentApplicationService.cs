using Evolent.Application.Adapters;
using Evolent.Application.Contract;
using Evolent.DomainModel;
using Evolent.Service.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evolent.Application
{
    public class EvolentApplicationService : IEvolentApplicationService
    {
        private readonly IEvolentRepositoryFactory _repositoryFactory;
        private readonly DtoAdapter _dtoAdapter;
        private readonly DomainAdapter _domainAdapter;

        public EvolentApplicationService(IEvolentRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _domainAdapter = new DomainAdapter();
            _dtoAdapter = new DtoAdapter();
        }

        public Task<IEnumerable<PersonDto>> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> GetContactByIdAsync(int contactId)
        {
            using (var repository = _repositoryFactory.Create())
            {
                var contact = await repository.GetContactByIdAsync(contactId).ConfigureAwait(false);
                return _domainAdapter.Adapt(contact);
            }
        }

        public Task<PersonDto> SaveContactAsync(PersonDto contact)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> UpdateContactAsync(PersonDto contact)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteContactAsync(int contactId)
        {
            throw new NotImplementedException();
        }
    }
}
