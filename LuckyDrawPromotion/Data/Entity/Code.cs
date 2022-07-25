using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Data.Entity
{
    [Table("Code")]
    public class Code
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public string Target { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Type { get; set; }
        public int UsedCount { get; set; }
        [Range(-1, int.MaxValue)]
        public int LimitUsage { get; set; } // -1: Unlimited
        public string NameCampaign { get; set; }
        public Guid IdGift { get; set; }

        public Campaign Campaign { get; set; }
        public Gift Gift { get; set; }
        public List<Award> Awards { get; set; }
    }
}
