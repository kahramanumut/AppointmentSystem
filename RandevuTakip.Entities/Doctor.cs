using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RandevuTakip.Entities
{
    [Table("tbl_doctors")]
    public class Doctor:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
