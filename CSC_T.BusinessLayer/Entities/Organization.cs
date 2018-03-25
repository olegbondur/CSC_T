using System.Collections.Generic;

namespace CSC_T.BusinessLayer.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public OrganizationType Type { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}
