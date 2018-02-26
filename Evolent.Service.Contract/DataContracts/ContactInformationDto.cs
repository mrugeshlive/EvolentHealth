using System.Runtime.Serialization;

namespace Evolent.Service.Contract.DataContracts
{
    [DataContract]
    public class ContactInformationDto
    {
        public int PersonId { get; set; }

        [DataMember]
        public string EmailId { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
