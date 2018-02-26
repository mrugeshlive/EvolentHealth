
namespace Evolent.DomainModel.Models
{
    public class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
        public ContactInformation ContactInformation { get; set; }
        public bool IsActive { get; set; }
    }
}
