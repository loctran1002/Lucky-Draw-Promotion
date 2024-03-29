﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDrawPromotion.Models.Entity
{
    [Table("InsCode")]
    public class InsCode
    {
        public int Id { get; set; }
        public string Charset { get; set; }
        [Range(0, int.MaxValue)]
        public int Length { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string NameCampaign { get; set; }

        public Campaign Campaign { get; set; }
    }
}
