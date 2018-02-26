using Evolent.DomainModel.Models;
using Evolent.Service.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Application.Adapters
{
    public class DomainAdapter
    {
        public PersonDto Adapt(Person entity)
        {
            if (entity == null)
                return null;
            var personDto = new PersonDto { Id = entity.Id, FirstName = entity.FirstName, LastName = entity.LastName, ContactInformation = new ContactInformationDto(), IsActive = entity.IsActive };

            if (entity.ContactInformation != null)
                personDto.ContactInformation = Adapt(entity.ContactInformation);

            return personDto;
        }

        public ContactInformationDto Adapt(ContactInformation entity)
        {
            return entity == null ? null : new ContactInformationDto { EmailId = entity.EmailId, PhoneNumber = entity.PhoneNumber, PersonId = entity.PersonId };
        }
    }
}
