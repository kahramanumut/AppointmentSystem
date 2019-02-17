using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class EfDepartmentRepository : EfGenericRepository<Department>, IDepartmentRepository
    {
        public EfDepartmentRepository(AppointmentDbContext _context) : base(_context)
        {
        }
    }
}
