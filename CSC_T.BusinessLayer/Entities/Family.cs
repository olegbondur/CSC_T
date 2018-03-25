using System.Collections.Generic;


namespace CSC_T.BusinessLayer.Entities
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public ICollection<Offering> Offerings { get; set; }
    }
}
