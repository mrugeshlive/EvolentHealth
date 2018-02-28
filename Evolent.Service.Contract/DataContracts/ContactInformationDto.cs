using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Evolent.Service.Contract.DataContracts
{
    [DataContract]
    public class ContactInformationDto
    {
        [DataMember]
        [Required]
        public string EmailId { get; set; }

        [DataMember]
        [Required]
        public string MobileNumber { get; set; }
    }
}
