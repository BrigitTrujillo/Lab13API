namespace Lab13API.Models
{
    public class Product
    {
        internal bool IsActive;

        public int ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public bool Active { get; set; }


        public Category? category { get; set; }
        public int? CategoryID { get; set; }
    }
}
