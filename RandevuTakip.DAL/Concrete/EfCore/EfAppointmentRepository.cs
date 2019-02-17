using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class EfAppointmentRepository : EfGenericRepository<Appointment>, IAppointmentRepository
    {

        public EfAppointmentRepository(AppointmentDbContext _context) : base(_context)
        {
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            var appointmentList = FindBy(x => x.Doctor.Id == doctorId).Select(x=> new Appointment { Patient = x.Patient, Timestamp= x.Timestamp , Id=x.Id }).ToList();
            return appointmentList;
        }

        public List<Appointment> GetReservedAppointmentsByPatientId(int patientId)
        {
            var reserveds = FindBy(x => x.Patient.Id == patientId).Select(x=> new Appointment { Doctor =x.Doctor, Patient=x.Patient, Department=x.Department , Timestamp = x.Timestamp, Id =x.Id }).ToList();
            return reserveds;
        }
    }
}
