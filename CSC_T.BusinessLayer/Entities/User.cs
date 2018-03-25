using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CSC_T.BusinessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
