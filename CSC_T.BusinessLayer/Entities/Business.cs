using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSC_T.BusinessLayer.Entities
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CountryBusiness> CountryBusiness { get; set; }

        public Business()
        {
            CountryBusiness = new Collection<CountryBusiness>();
        }

        public ICollection<Family> Families { get; set; }
    }
}
