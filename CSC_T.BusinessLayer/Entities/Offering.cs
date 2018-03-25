using System.Collections.Generic;


namespace CSC_T.BusinessLayer.Entities
{
    public class Offering
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FamilyId { get; set; }
        public Family Family { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
