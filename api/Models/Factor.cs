using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models 
{
    [Table("Factor")]
    public class Factor
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinalPrice { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser User { get; set; }
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}