using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Contracts
{
	public interface IRoom
	{
		public Task<IEnumerable<Room>> Read();
		
	}
}
