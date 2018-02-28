using Evolent.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evolent.DomainModel
{
    public interface IEvolentRepository : IDisposable
    {
        Task<IEnumerable<Person>> GetAllContactsAsync();
        Task<Person> GetContactByIdAsync(int contactId);
        Task<bool> SaveContactAsync(Person contact);
        Task<bool> DeleteContactAsync(int contactId);
        Task<bool> UpdateContactAsync(Person contact);
    }
}
