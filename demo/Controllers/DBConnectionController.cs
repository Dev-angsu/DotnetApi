using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzoneApp.Data;
using System.Collections.Specialized;
using System.ComponentModel;

namespace demo.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DBConnectionController : Controller
    {
        private readonly OzoneDataContext _db;
        public DBConnectionController(OzoneDataContext db)
        {
            _db = db;   
        }
        [Route("/api/[controller]/GetAllRooms")]
        [HttpGet]
        public async Task<List<room>> GetAllRooms()
        {
            return await _db.room.ToListAsync();
        }
        [Route("/api/[controller]/CreateRoom")]
        [HttpPost]
        public async Task<bool> CreateRoom()
        {
                var result = _db.Entry("insert into room values(2, 'Burrow', 'burrow@icicilombard.meetingroom.com', 3, 'conference room', ARRAY['',''],'1');");
                return true;
            
        }
    }
}
