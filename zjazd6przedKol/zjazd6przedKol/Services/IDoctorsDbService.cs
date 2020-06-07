using cw6.DTOs;
using cw6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public interface IDoctorsDbService
    {
        public IEnumerable<DoctorDto> GetDoctors();

        public DoctorDto GetDoctor(int id);

        public NewDoctorDto AddDoctor(NewDoctorDto newDoctor);

        public NewDoctorDto UpdateDoctor(int id, NewDoctorDto updatedDoctor);

        public string DeleteDoctors(int id);
    }
}
