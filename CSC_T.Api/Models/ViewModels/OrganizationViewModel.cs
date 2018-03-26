using CSC_T.BusinessLayer.Entities;

namespace CSC_T.Api.Models.ViewModel
{
    public class OrganizationViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public OrganizationType Type { get; set; }
        public string OwnerId { get; set; }
    }
}
