
using Evolent.Service.Contract.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evolent.Application.Contract
{
    public interface IEvolentApplicationService
    {
        Task<IEnumerable<PersonDto>> GetAllContacts();
        Task<PersonDto> GetContactByIdAsync(int contactId);
        Task<PersonDto> SaveContactAsync(PersonDto contact);
        Task<bool> DeleteContactAsync(int contactId);
        Task<PersonDto> UpdateContactAsync(PersonDto contact);
    }
}
