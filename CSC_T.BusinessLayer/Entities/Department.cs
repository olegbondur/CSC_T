
namespace CSC_T.BusinessLayer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OfferingId { get; set; }
        public Offering Offering { get; set; }
    }
}
