using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementModule.EntityModel;

namespace ManagementModule.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ManagementModule.EntityModel.ManagementModuleContext _context;

        public IndexModel(ManagementModule.EntityModel.ManagementModuleContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
