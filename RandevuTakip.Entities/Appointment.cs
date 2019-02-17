using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RandevuTakip.Entities
{
    [Table("tbl_appointments")]
    public class Appointment:EntityBase
    {
        public Patient Patient { get; set; }
        public Department Department { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
