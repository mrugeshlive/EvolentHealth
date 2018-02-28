using AutoMapper;
using Evolent.DomainModel.Models;
using Evolent.Service.Contract.DataContracts;

namespace Evolent.Application.EntityMappers
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<ContactInformation, ContactInformationDto>();

            CreateMap<Person, PersonDto>();
            CreateMap<ContactInformationDto, ContactInformation>();
        }
    }
}
