using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;

namespace RandevuTakip.WebApp.Api
{
    [Route("api/appointment/[action]")]
    [ApiController]
    public class AppointmentServicesController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepo;
        public AppointmentServicesController(IAppointmentRepository _appointmentRepo)
        {
            appointmentRepo = _appointmentRepo;
        }

        [HttpPost]
        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return appointmentRepo.GetAppointmentsByDoctorId(doctorId);
        }

        [HttpPost]
        public List<string> GetAvailableAppointments(int doctorId, string date)
        {
            var appointmentList = GetAppointmentsByDoctorId(doctorId);
            var time = Convert.ToDateTime(date);

            time = time.AddHours(9);
            List<string> appointments = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                if (appointmentList.Where(x=>x.Timestamp == time).Count() == 0)
                    appointments.Add(time.ToShortTimeString());

                time = time.AddMinutes(30);
            }
            return appointments;
        
        }
    }
}