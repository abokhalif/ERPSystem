using System.ComponentModel.DataAnnotations;

namespace UltimateAPI.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        [MaxLength(2, ErrorMessage = "More than 2 char")]
        public string Name { get; set; }
    }
}
