namespace DemoShopping.Models
{
    public class ListProduct
    {
        
        public int ListID { get; set; }
        public List List { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public bool isPurchased { get; set; }
    }
}
