using Demo.Models;

namespace Day4_ModelBinding.Models
{
    public class Dapartment
    {

            public int Id { get; set; }
            public string Name { get; set; }
        public string Description { get; set; }
            public string ManagerName { get; set; }
        public int ManagerId { get; set; }
        public int ManagerType { get; set; }
    }
}
