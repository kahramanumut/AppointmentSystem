using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RandevuTakip.Entities
{
    [Table("tbl_departments")]
    public class Department:EntityBase
    {
        public string DepartmentName { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
