using RandevuTakip.DAL.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RandevuTakip.Entities.Identity.Security;
using RandevuTakip.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.WebSockets.Internal;
using RandevuTakip.Entities.Identity;

namespace RandevuTakip.WebApp.Data
{
    public static class SeedData     
    {
        public static async Task Seed(IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            AppointmentDbContext appContext = serviceProvider.GetRequiredService<AppointmentDbContext>();
            ApplicationDbContext identityContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            appContext.Database.Migrate();

            if (!appContext.Doctors.Any())
            {
                await SeedEverything(appContext);
            }

            //var adminID = await EnsureUser(serviceProvider, "1234", "admin@admin.com",0);
            //await EnsureRole(serviceProvider, adminID, RandevuTakip.Entities.Identity.Security.Constants.AdministratorsRole);

            var sampleDoctor = await EnsureUser<Doctor>(serviceProvider, "1234", "umut@umut.com", appContext.Doctors.SingleOrDefault(x=>x.Surname=="Kahraman").UserGuidId);
            await EnsureRole(serviceProvider, sampleDoctor, RandevuTakip.Entities.Identity.Security.Constants.Doctor);

            var sampleDoctor2 = await EnsureUser<Doctor>(serviceProvider, "1234", "yusa@yusa.com", appContext.Doctors.SingleOrDefault(x => x.Surname == "Açıkalın").UserGuidId);
            await EnsureRole(serviceProvider, sampleDoctor2, RandevuTakip.Entities.Identity.Security.Constants.Doctor);

            var sampleDoctor3 = await EnsureUser<Doctor>(serviceProvider, "1234", "serhat@serhat.com", appContext.Doctors.SingleOrDefault(x => x.Surname == "Denek").UserGuidId);
            await EnsureRole(serviceProvider, sampleDoctor3, RandevuTakip.Entities.Identity.Security.Constants.Doctor);

            var samplePatient = await EnsureUser<Patient>(serviceProvider, "1234", "federer@federer.com", appContext.Patients.SingleOrDefault(x => x.Surname == "Federer").UserGuidId);
            await EnsureRole(serviceProvider, samplePatient, RandevuTakip.Entities.Identity.Security.Constants.Patient);

            var samplePatient2 = await EnsureUser<Patient>(serviceProvider, "1234", "mustafa@mustafa.com", appContext.Patients.SingleOrDefault(x => x.Surname == "Gelirgeçer").UserGuidId);
            await EnsureRole(serviceProvider, samplePatient2, RandevuTakip.Entities.Identity.Security.Constants.Patient);
        }

        private static async Task<string> EnsureUser<T>(IServiceProvider serviceProvider, string testUserPw, string email, string userId)
        {
            
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser { Email= email, UserName = email , UserGuidId = userId };
                user.EmailConfirmed = true;
                var r = await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        private static async Task SeedEverything(AppointmentDbContext context)
        {
            //DEPARTMENTS
            var departments = new List<Department>
            {
                new Department { DepartmentName = "KBB"},
                new Department { DepartmentName = "Kardiyoloji"},
                new Department { DepartmentName = "Onkoloji"},
                new Department { DepartmentName = "Cildiye"},
            };
            await context.Departments.AddRangeAsync(departments);

            //DOCTORS
            var doctors = new List<Doctor>
            {
                new Doctor { Name = "Umut", Surname="Kahraman", Department= departments[0]},
                new Doctor { Name = "Yuşa", Surname="Açıkalın", Department= departments[2]},
                new Doctor { Name = "Serhat", Surname="Denek", Department= departments[3]},
            };
            await context.Doctors.AddRangeAsync(doctors);

            //PATIENTS
            var patients = new List<Patient>
            {
                new Patient { Name="Roger", Surname="Federer", Address="Kuzey Kaliforniya", BirthDate = DateTime.Now.AddYears(-30),IdentityNo="12345678900",Phone="5066132095" },
                new Patient { Name="Mustafa", Surname="Gelirgeçer", Address="Sivas", BirthDate = DateTime.Now.AddYears(-20).AddDays(85),IdentityNo="4562345345",Phone="5317985689" },
                new Patient { Name="Mahmut", Surname="Tuncer", Address="Los Angeles", BirthDate = DateTime.Now.AddYears(-30).AddDays(15),IdentityNo="99999999999",Phone="6985632145" },
                new Patient { Name="İsmail", Surname="Eşel", Address="Talas", BirthDate = DateTime.Now.AddYears(-25).AddDays(85),IdentityNo="23443534534",Phone="345234445" },
                new Patient { Name="Gökçe", Surname="Boz", Address="Kayseri", BirthDate = DateTime.Now.AddYears(-26).AddDays(85),IdentityNo="324234234234",Phone="3453453455" }
            };
            await context.Patients.AddRangeAsync(patients);

            //APPOINTMENTS
            var appointments = new List<Appointment>
            {
                new Appointment { Department=departments[0], Doctor= doctors[0], Patient = patients[0], Timestamp= DateTime.Parse("2018-11-11 09:00") },
                new Appointment { Department=departments[2], Doctor= doctors[1], Patient = patients[1], Timestamp= DateTime.Parse("2018-11-11 10:00") },
                new Appointment { Department=departments[2], Doctor= doctors[1], Patient = patients[2], Timestamp= DateTime.Parse("2018-11-11 11:00") },
                new Appointment { Department=departments[3], Doctor= doctors[2], Patient = patients[3], Timestamp= DateTime.Parse("2018-11-11 12:00") },
                new Appointment { Department=departments[3], Doctor= doctors[2], Patient = patients[4], Timestamp= DateTime.Parse("2018-11-11 11:30") },
                new Appointment { Department=departments[2], Doctor= doctors[1], Patient = patients[1], Timestamp= DateTime.Parse("2018-11-11 12:30") },
                new Appointment { Department=departments[0], Doctor= doctors[0], Patient = patients[2], Timestamp= DateTime.Parse("2018-11-11 14:30") }
            };                                                                                                     
            await context.Appointments.AddRangeAsync(appointments);

            await context.SaveChangesAsync();

        }
    }
}
