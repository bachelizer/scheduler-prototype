using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Contracts
{
	public interface IInstructor
	{
		public Task<IEnumerable<Instructor>> Read();
		public Task<IEnumerable<OfferedSubject>> FetchHandledSubjects(int instructor_id);
		public Task<IEnumerable<Instructor>> FetchPWDInstructors();
        public Task Create(Instructor data);
        public Task Update(Instructor data);
        public Task Delete(int instuctor_id);
		
	}
}
