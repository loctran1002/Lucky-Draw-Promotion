using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Models.Entity
{
    [Table("Award")]
    public class Award
    {
        public Guid Id { get; set; }
        public string IdCode { get; set; }
        public string PhoneNumberUser { get; set; }
        public DateTime? UsedDate { get; set; }
        public bool IsSent { get; set; }

        public Code Code { get; set; }
        public User User { get; set; }
    }
}
