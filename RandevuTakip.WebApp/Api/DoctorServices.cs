using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandevuTakip.DAL.Abstract;

namespace RandevuTakip.WebApp.Api
{
    [Route("api/doctor/[action]")]
    [ApiController]
    public class DoctorServices : ControllerBase
    {
        private readonly IDoctorRepository doctorRepo;
        public DoctorServices(IDoctorRepository _doctorRepo)
        {
            doctorRepo = _doctorRepo;
        }

    }
}