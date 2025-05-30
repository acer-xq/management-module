namespace ManagementModule.EntityModel
{
    public static class DbInitialiser {
        public static void Initialise(ManagementModuleContext context) {
            if (context.Products.Any()) {
                return;
            }

            var products = new Product[]
            {
                new Product { Id = 1, Name = "Apple", Description = "This is an apple", Price = 0.99M, Stock = 19, IsActive = true },
                new Product { Id = 2, Name = "Apple but better", Description = "This is in some way better than a regular apple", Price = 2.00M, Stock = 8, IsActive = true },
                new Product { Id = 3, Name = "Brick", Description = "Probably has some use", Price = 0.85M, Stock = 583, IsActive = true },
                new Product { Id = 4, Name = "Can", Description = "Nondescript contents", Price = 2.10M, Stock = 8, IsActive = true },
                new Product { Id = 5, Name = "Watch", Description = "Watch what?", Price = 46.00M, Stock = 5, IsActive = true },
                new Product { Id = 6, Name = "Lawn mower", Description = "It's a really good one don't question it", Price = 2650.00M, Stock = 1, IsActive = true },
                new Product { Id = 7, Name = "Discontinued product", Description = "Whatever it is it's not for sale", Price = 5.99M, Stock = 21, IsActive = false },
                new Product { Id = 8, Name = "Inferior apple", Description = "No one wants these", Price = 0.79M, Stock = 4, IsActive = false },
                new Product { Id = 9, Name = "';DROP TABLE Products;--", Description = "Little bobby tables we call him", Price = -1M, Stock = -1, IsActive = false },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
