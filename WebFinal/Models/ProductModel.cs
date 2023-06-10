namespace WebFinal.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        public string ProductName { get; set; } = null!;

        public long ProductCategory { get; set; }

        public string ProductCategoryName { get; set; }

        public decimal ProductPrize { get; set; }

        public long ProductStock { get; set; }

    }
}
