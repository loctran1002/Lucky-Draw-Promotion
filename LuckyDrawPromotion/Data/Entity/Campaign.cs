using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Data.Entity
{
    [Table("Campaign")]
    public class Campaign
    {
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Description { get; set; }
        public bool AutoUpdate { get; set; }
        public bool UseOnlyOnce { get; set; }
        public string EmailAdmin { get; set; }
        public Guid IdSetting { get; set; }

        public List<Log>? Logs { get; set; }
        public List<InsCode>? InsCodes { get; set; }
        public List<Code>? Codes { get; set; }
        public List<Rule>? Rules { get; set; }
        public Admin? Admin { get; set; }
        public Setting? Setting { get; set; }
    }
}
