using ManagementModule.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementModule.Models {
    public class ProductIndexViewModel {
        public List<Product> Products { get; set; }
        public ProductFilterModel Filter { get; set; }
    }
}
