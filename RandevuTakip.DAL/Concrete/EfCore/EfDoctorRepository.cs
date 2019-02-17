using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class EfDoctorRepository : EfGenericRepository<Doctor>, IDoctorRepository
    {
        public EfDoctorRepository(AppointmentDbContext _context) : base(_context)
        {
        }
    }
}
