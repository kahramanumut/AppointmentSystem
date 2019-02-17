using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class EfPatientRepository : EfGenericRepository<Patient>, IPatientRepository
    {
        public EfPatientRepository(AppointmentDbContext _context) : base(_context)
        {
        }
    }
}
