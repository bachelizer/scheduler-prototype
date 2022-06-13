using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Model;
using backend.Contracts;

namespace backend.Controllers
{
    [Route("instructor")]
    [ApiController]
    public class InstructorController:ControllerBase
    {
        private readonly IInstructor _instructorrepo;
        public InstructorController(IInstructor instructorrepo)
        {
            _instructorrepo = instructorrepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Instructor>> ReadAsync()
        {
            return await _instructorrepo.Read();
        }
        [HttpGet]
        [Route("handled-subjects")]
        public async Task<IEnumerable<OfferedSubject>> FetchHandledSubjects(int instructor_id)
        {
            return await _instructorrepo.FetchHandledSubjects(instructor_id);
        }
        [HttpGet]
        [Route("pwd")]
        public async Task<IEnumerable<Instructor>> FetchPWDInstructors()
        {
            return await _instructorrepo.FetchPWDInstructors();
        }
        [HttpPost]
        public async Task CreateAsync(Instructor data)
        {
            await _instructorrepo.Create(data);
        }
        [HttpPut]
        public async Task UpdateAsync(Instructor data)
        {
            await _instructorrepo.Update(data);
        }
        [HttpDelete]
        public async Task DeleteAsync(int instuctor_id)
        {
            await _instructorrepo.Delete(instuctor_id);
        }

    }
}