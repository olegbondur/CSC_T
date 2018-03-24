using Microsoft.AspNetCore.Identity;

namespace CSC_T.BusinessLayer.Entities
{
    public class BaseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
    }
}
