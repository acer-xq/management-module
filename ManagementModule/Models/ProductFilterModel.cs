namespace ManagementModule.Models {
    public class ProductFilterModel {
        public string? SearchTerm { get; set; }
        public bool Active { get; set; }
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}
