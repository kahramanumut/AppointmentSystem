using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using RandevuTakip.Entities.Identity;
using RandevuTakip.Entities.Identity.Security;

namespace RandevuTakip.WebApp.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository appointmentRepo;
        private readonly IDoctorRepository doctorRepo;
        private readonly IPatientRepository patientRepo;
        private readonly IDepartmentRepository departmentRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public AppointmentController(IAppointmentRepository _appointmentRepo,
                                     IDoctorRepository _doctorRepo, IPatientRepository _patientRepo, IDepartmentRepository _departmentRepo, UserManager<ApplicationUser> _userManager)
        {
            appointmentRepo = _appointmentRepo;
            doctorRepo = _doctorRepo;
            patientRepo = _patientRepo;
            departmentRepo = _departmentRepo;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Reserved()
        {
            List<Appointment> reserveds = new List<Appointment>();

            var user = await userManager.GetUserAsync(User);          
            var role = await userManager.GetRolesAsync(user);

            if (role[0].Equals(Constants.Patient))
            {
                reserveds = appointmentRepo.GetReservedAppointmentsByPatientId(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                return View(reserveds);
            }
            else
            {
                reserveds = appointmentRepo.GetAppointmentsByDoctorId(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                return View("Appointments", reserveds);         
            }

        }

        [Authorize(Roles = Constants.Patient)]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public bool MakeAppointment(int patientId ,int doctorId, int departmentId ,string date)
        {
            Appointment appointment = new Appointment();
            appointment.Doctor = doctorRepo.FindById(doctorId);
            appointment.Patient = patientRepo.FindById(patientId);
            appointment.Department = departmentRepo.FindById(departmentId);
            appointment.Timestamp = Convert.ToDateTime(date);

            try
            {
                appointmentRepo.Add(appointment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}