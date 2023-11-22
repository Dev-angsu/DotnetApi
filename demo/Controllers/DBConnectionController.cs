using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OzoneApp.Data;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DBConnectionController : Controller
    {
        private readonly ILogger<DBConnectionController> _logger;
        private readonly OzoneDataContext _db;
        public DBConnectionController(OzoneDataContext db, ILogger<DBConnectionController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [Route("GetAllRooms")]
        [HttpGet]
        public async Task<List<room>> GetAllRooms()
        {
            return await _db.room.ToListAsync();
        }
        [Route("CreateRoom")]
        [HttpPost]
        public async Task<bool> CreateRoom(room roomInput)
        {
            //_db.Add(new room { id = 3, name = "Nest", email = "nest@icicilombard.meetingroom.com", roomcapacity = 2, roomtype = "conference room", floor = "2", facilities = "AC" });
            _db.Add(roomInput);
            _db.SaveChanges();
            return true;
        }
        [Route("CreateRoomFromForm")]
        [HttpPost]
        public async Task<bool> CreateRoomFromForm([FromForm]room roomInput)
        {
            //_db.Add(new room { id = 3, name = "Nest", email = "nest@icicilombard.meetingroom.com", roomcapacity = 2, roomtype = "conference room", floor = "2", facilities = "AC" });
            _db.Add(roomInput);
            _db.SaveChanges();
            return true;
        }
        [Route("ModifyRoom")]
        [HttpPatch]
        public async Task<bool> ModifyRoom(int roomid, int newval)
        {
            try {
                var result = _db.room.SingleOrDefault(b => b.id == roomid);
                _logger.LogInformation("Found Room corresponding to RoomID given");
                if (result != null)
                {
                    result.roomcapacity = newval;
                    _db.SaveChanges();
                    _logger.LogInformation("Updating Row with new RoomCapacity");
                }
                else
                {
                    _logger.LogInformation("No such Row found");
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [Route("DeleteRoom")]
        [HttpDelete]
        public async Task<bool> DeleteRoom()
        {
            int roomid = 3;
            var result = _db.room.SingleOrDefault(b => b.id == roomid);
            _db.Remove(result);
            _db.SaveChanges();
            return true;
        }
        [Route("getByID/{roomid}")]
        [HttpPatch]
        public async Task<room> getByID([FromRoute]int roomid)
        {
            try
            {
                var result = _db.room.SingleOrDefault(b => b.id == roomid);
                if (result != null)
                {
                    Console.WriteLine("Yes we got");
                }
                else
                {
                    throw new Exception();
                }
                //return true;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
