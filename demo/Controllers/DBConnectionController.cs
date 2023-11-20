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
        [HttpGet]
        public async Task<List<room>> GetAllRooms()
        {
            return await _db.room.ToListAsync();
        }
    }
}
