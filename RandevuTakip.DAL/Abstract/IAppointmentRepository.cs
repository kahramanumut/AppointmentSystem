using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandevuTakip.DAL.Abstract
{
    public interface IAppointmentRepository:IDalGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByDoctorId(int doctorId);
        List<Appointment> GetReservedAppointmentsByPatientId(int patientId);
    }
}
