using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace i1.Models
{
    [Table("Indices")]
    public class Indice
    {
        [Required(ErrorMessage = "Index Id is required")]
        [RegularExpression(@"^[I]+[0-9]{3}$", ErrorMessage = "Index Id starts whith I")]
        public string IndexId { get; set; }
        [Required(ErrorMessage = "Index Name is required")]
        [StringLength(20, ErrorMessage = "Length Should be Less than 20")]
        public string IndexName { get; set; }
        public DateTime IndexInsertionDate { get; set; }
        [Required]
        public string LoginId { get; set; }
    }
}