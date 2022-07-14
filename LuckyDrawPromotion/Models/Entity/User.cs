using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Models.Entity
{
    [Table("User")]
    public class User : IdentityUser<Guid>
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string Positon { get; set; }
        public string TypeBusiness { get; set; }
        public bool Block { get; set; }

        public List<Award>? Awards { get; set; }
    }
}
