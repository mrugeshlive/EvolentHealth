using AutoMapper;
using Evolent.Application.Contract;
using Evolent.DomainModel;
using Evolent.DomainModel.Models;
using Evolent.Service.Contract.DataContracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Application
{
    public class EvolentApplicationService : IEvolentApplicationService
    {
        private readonly IEvolentRepositoryFactory _repositoryFactory;

        public EvolentApplicationService(IEvolentRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IEnumerable<PersonDto>> GetAllContacts()
        {
            var allContacts = new List<PersonDto>();
            using (var repository = _repositoryFactory.Create())
            {
                var contacts = await repository.GetAllContactsAsync().ConfigureAwait(false);
                if (contacts.Any())
                    allContacts.AddRange(Mapper.Map<List<PersonDto>>(contacts));
                return allContacts;
            }
        }

        public async Task<PersonDto> GetContactByIdAsync(int contactId)
        {
            using (var repository = _repositoryFactory.Create())
            {
                var contact = await repository.GetContactByIdAsync(contactId).ConfigureAwait(false);
                if (contact != null)
                    return Mapper.Map<PersonDto>(contact);
                return null;
            }
        }

        public async Task<bool> SaveContactAsync(PersonDto contact)
        {
            using (var repository = _repositoryFactory.Create())
            {
                return await repository.SaveContactAsync(Mapper.Map<Person>(contact)).ConfigureAwait(false);
            }
        }

        public async Task<bool> UpdateContactAsync(PersonDto contact)
        {
            using (var repository = _repositoryFactory.Create())
            {
                return await repository.UpdateContactAsync(Mapper.Map<Person>(contact)).ConfigureAwait(false);
            }
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            using (var repository = _repositoryFactory.Create())
            {
                return await repository.DeleteContactAsync(contactId).ConfigureAwait(false);
            }
        }
    }
}
