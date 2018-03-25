using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace CSC_T.BusinessLayer.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        
        public ICollection<CountryBusiness> CountryBusiness { get; set; }

        public Country()
        {
            CountryBusiness = new Collection<CountryBusiness>();
        }
    }
}
