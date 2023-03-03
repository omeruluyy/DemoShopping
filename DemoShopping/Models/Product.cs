namespace DemoShopping.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string imageUrl { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<ListProduct> Lists  { get; set; }
    }
}
