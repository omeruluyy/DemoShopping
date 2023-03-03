using System.ComponentModel.DataAnnotations;

namespace DemoShopping.Models
{
    public class List
    {
        
        public int ListID { get; set; }
        public string Title { get; set; }
        public bool isEnable { get; set; }
        public User User { get; set; }
        public ICollection<ListProduct> Products { get; set; }
    }
}
