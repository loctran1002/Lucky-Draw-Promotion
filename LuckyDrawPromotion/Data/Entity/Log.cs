using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Data.Entity
{
    [Table("Log")]
    public class Log
    {
        public int Priority { get; set; }
        public string Content { get; set; }
        public string NameCampaign { get; set; }

        public Campaign? Campaign { get; set; }
    }
}
