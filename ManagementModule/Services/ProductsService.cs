using ManagementModule.EntityModel;
using ManagementModule.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementModule.Services {
    public class ProductsService {
        private readonly ManagementModuleContext _context;

        public ProductsService(ManagementModuleContext context) {
            _context = context;
        }

        public async Task<Product?> GetIfExists(int? id) {
            if (id == null) return null;
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetList() {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetFilteredList(ProductFilterModel filter) {
            var query = _context.Products.AsQueryable();

            query = query.Where(p => p.IsActive == filter.Active);

            if (!string.IsNullOrEmpty(filter.SearchTerm)) {
                query = query.Where(p => p.Name.ToUpper().Contains(filter.SearchTerm.ToUpper()));
            }

            if (filter.StockMin.HasValue) {
                query = query.Where(p => p.Stock >=  filter.StockMin);
            }

            if (filter.StockMax.HasValue) {
                query = query.Where(p => p.Stock <= filter.StockMax);
            }

            if (filter.PriceMin.HasValue) {
                query = query.Where(p => p.Price >= filter.PriceMin);
            }

            if (filter.PriceMax.HasValue) {
                query = query.Where(p => p.Price <= filter.PriceMax);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> Create(Product product) {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> Update(Product product) {
            try {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException) {
                if (!await _context.Products.AnyAsync(p => p.Id == product.Id)) {
                    return null;
                }
                else {
                    throw;
                }
            }
        }

        public async Task Delete(int? id) {
            var product = await _context.Products.FindAsync(id);
            if (product != null) {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
        }
    }
}
