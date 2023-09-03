using System.ComponentModel.DataAnnotations;

namespace IAP.Infrustructure.Models
{
    public class CompanyModel
    {
        [Required]
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyType { get; set; }
        public int CompanyStatus { get; set; }
        public string? Description { get; set; }
    }
}
