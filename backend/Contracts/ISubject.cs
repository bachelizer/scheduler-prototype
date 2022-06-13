using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Contracts
{
	public interface ISubject
	{
		public Task<IEnumerable<OfferedSubject>> FetchOfferedSubjects();
		public Task<IEnumerable<OfferedSubject>> FetchLaboratorySubjects();
		public Task<IEnumerable<OfferedSubject>> FetchLectureSubjects();
		
	}
}