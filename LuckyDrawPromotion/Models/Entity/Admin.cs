using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Models.Entity
{
    [Table("Admin")]
    public class Admin : IdentityUser<Guid>
    {
        public string Fullname { get; set; }

        public List<Campaign> Campaigns { get; set; }
    }
}
