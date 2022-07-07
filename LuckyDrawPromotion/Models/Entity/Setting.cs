using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Models.Entity
{
    [Table("Setting")]
    public class Setting
    {
        public Guid Id { get; set; }
        public string GenQR { get; set; }
        public string LanddingPage { get; set; }
        public string SMSText { get; set; }
        public bool DailyReport { get; set; }
        public DateTime TimeSend { get; set; }
        public string Email { get; set; }

        public Campaign Campaign { get; set; }
    }
}
