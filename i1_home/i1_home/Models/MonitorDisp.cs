using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace i1.Models
{
    [Table("IndexMonitor")]
    public class MonitorDisp
    {
        public string IndexId { get; set; }
        public string ProcessingStatus { get; set; }
        public DateTime RecordInsertionDate { get; set; }

    }
}