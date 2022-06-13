using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Contracts
{
	public interface IAuth
	{
		public Task<User> Auth(string username, string password);
		
	}
}
