namespace Lab13API.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool active { get; set; }


        public Category? category { get; set; }
        public int? CategoryID { get; set; }
    }
}
