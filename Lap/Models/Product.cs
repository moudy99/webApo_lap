using System.ComponentModel.DataAnnotations.Schema;

namespace Lap.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int price { get; set; }

        [ForeignKey("Category")]
        public int? categoryID { get; set; }
        public Category? Category { get; set; }
    }
}
