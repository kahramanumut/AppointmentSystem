using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandevuTakip.DAL.Abstract;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevuTakip.WebApp.Api
{
    [Route("api/department/[action]")]
    [ApiController]
    public class DepartmentServices:ControllerBase
    {
        private readonly IDepartmentRepository departmentRepo;
        public DepartmentServices(IDepartmentRepository _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }

        [HttpGet]
        public List<Department> GetDepartments()
        {
            var departments = departmentRepo.GetAll().ToList();
            return departments;
        }

        [HttpGet]
        public List<Doctor> GetDoctorsByDepartmentId(int id)
        {

            var doctorList = departmentRepo.FindBy(x=>x.Id == id).Select(x=>x.Doctors).FirstOrDefault();
            return doctorList;
        }
    }
}
