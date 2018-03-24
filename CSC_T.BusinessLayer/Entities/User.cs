
namespace CSC_T.BusinessLayer.Entities
{
   public class User
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public BaseUser Identity { get; set; }
        public string Address { get; set; }
    }
}
