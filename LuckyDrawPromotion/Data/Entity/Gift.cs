using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Data.Entity
{
    [Table("Gift")]
    public class Gift
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Code>? Codes { get; set; }
        public List<Rule>? Rules { get; set; }
    }
}