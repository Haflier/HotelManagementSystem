using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models 
{
    [Table("Service")]
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public ICollection<RoomService> RoomServices { get; set; }
    }
}