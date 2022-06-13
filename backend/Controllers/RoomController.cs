using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Model;
using backend.Contracts;

namespace backend.Controllers
{
    [Route("room")]
    [ApiController]
    public class RoomController:ControllerBase
    {
        private readonly IRoom _roomrepo;
        public RoomController(IRoom roomrepo)
        {
            _roomrepo = roomrepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Room>> ReadAsync()
        {
            return await _roomrepo.Read();
        }
      
    }
}