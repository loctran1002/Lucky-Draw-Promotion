using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Data.Entity
{
    [Table("Rule")]
    public class Rule
    {
        public Guid Id { get; set; }
        public string Schedule { get; set; }
        [NotMapped]
        public TimeSpan StartTime { get; set; }
        [NotMapped]
        public TimeSpan? EndTime { get; set; }
        [Range(0, 100)]
        public int Probability { get; set; }
        [Range(0, int.MaxValue)]
        public int QuantityGift { get; set; }
        [Range(1, int.MaxValue)]
        public int Priority { get; set; }
        public bool Active { get; set; }
        public string NameCampaign { get; set; }
        public Guid IdGift { get; set; }

        public Campaign? Campaign { get; set; }
        public Gift? Gift { get; set; }
    }
}
