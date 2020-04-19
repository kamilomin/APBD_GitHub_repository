using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cw2.DAL;

namespace cwiczenia3.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        public readonly IStudentsDal _service;
        public EnrollmentController(IStudentsDal dalservice)
        {
            _service = dalservice;
        }
        private string ConString = "Data Source=db-mssql; Initial Catalog=s17911; Integrated Security=True";

        [HttpPost]
        public async Task<IActionResult> EnrollStudent()
        {
            using (var connect = new SqlConnection(ConString))
            using (var command = new SqlConnection())
            {
                command.Connection = connect;
                connect.Open();
                var tran = connect.BeginTransaction();

                try {

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
                var enrollment = new Enrollment();
                return CreatedAtAction("enroll", enrollment);

            }
        }




    }
    }
}