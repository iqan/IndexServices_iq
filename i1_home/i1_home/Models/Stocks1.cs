using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace i1.Models
{
     [Table("Stocks")]
    public class Stocks1
    {
        [Required]
        [RegularExpression(@"^[I]+[0-9]{3}$", ErrorMessage = "Index ID Start with I i.e. I123")]
        public string IndexId { get; set; }
        [Required]
        [RegularExpression(@"^[F]+[0-9]{3}$", ErrorMessage = "Fund ID Start with F i.e. F123")]
        public string FundId { get; set; }

        [Required]
        public string FundName { get; set; }
        [RegularExpression(@"^[0-9][8]$", ErrorMessage = "Please Use numbers only and valid amount.")]
        public double FundPrice { get; set; }
        public DateTime EffectiveDate { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Enter minimum threshold between 0 to 1000.")]
        [RegularExpression(@"^[1-9]+$", ErrorMessage = "Please Enter numbers only.")]
        public double MinimumThreshold { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Enter maximum threshold between 0 to 1000.")]
        [RegularExpression(@"^[1-9]+$", ErrorMessage = "Please Enter numbers only.")]
        public double MaximumThreshold { get; set; }
        public string LoginId { get; set; }

    }
}