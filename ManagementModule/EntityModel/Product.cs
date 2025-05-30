using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementModule.EntityModel
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(63)]
        public string Name { get; set; }

        [MaxLength(1023)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }
}
