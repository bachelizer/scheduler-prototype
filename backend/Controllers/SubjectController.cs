using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Model;
using backend.Contracts;

namespace backend.Controllers
{
    [Route("subject")]
    [ApiController]
    public class SubjectController:ControllerBase
    {
        private readonly ISubject _subjectrepo;
        public SubjectController(ISubject subjectrepo)
        {
            _subjectrepo = subjectrepo;
        }
        [HttpGet]
        [Route("offered")]
        public async Task<IEnumerable<OfferedSubject>> FetchOfferedSubjectsAsync()
        {
            return await _subjectrepo.FetchOfferedSubjects();
        }
        [HttpGet]
        [Route("laboratory")]
        public async Task<IEnumerable<OfferedSubject>> FetchLaboratorySubjects()
        {
            return await _subjectrepo.FetchLaboratorySubjects();
        }
        [HttpGet]
        [Route("lecture")]
        public async Task<IEnumerable<OfferedSubject>> FetchLectureSubjects()
        {
            return await _subjectrepo.FetchLectureSubjects();
        }
       

    }
}