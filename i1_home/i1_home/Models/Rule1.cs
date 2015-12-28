using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace i1.Models
{
    [Table("Rules")]
    public class Rule1
    {
            public string RuleId { get; set; }
            
            [Required]
            [StringLength(20, ErrorMessage = "Rule Length is less than 20")]
            public string RuleName { get; set; }
            [Required]
            public string RuleExpression { get; set; }
            public string RuleStatus { get; set; }
            public DateTime RuleCreationDate { get; set; }
            public string FundId { get; set; }
            public string LoginId { get; set; }
            
        
    }
    
}