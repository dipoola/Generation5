using Generation5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Generation5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase

    {
        private readonly AppDbContext _context;

        public HotelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetALLHotels()
        {
            var hotel = _context.Hotels.ToList();
            return Ok(hotel);
        }


        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetHotelById([FromRoute]int id)
        {
            var essentials = _context.Hotels.Find(id);
            return Ok(essentials);
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            Hotel hotel1= new Hotel();
            {
                hotel1.Name = hotel.Name;
                hotel1.Description = hotel.Description;
                hotel1.Location = hotel.Location;
                hotel1.Id = hotel.Id;
            };
            _context.Hotels.Add(hotel1);
            _context.SaveChanges();
            return Ok(hotel1);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult EditHotels(int id, Hotel hotels)
        {
            var existinguser = _context.Hotels.Find(id);
                if(existinguser != null)
            {
                existinguser.Name=hotels.Name;
                existinguser.Description=hotels.Description;
                existinguser.Location=hotels.Location;    
                existinguser.Id = hotels.Id;
                _context.SaveChanges();
                return Ok(existinguser);

            }
               return NotFound();
        }

       
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteHotels([FromRoute]int id)
        {
            var lokoja = _context.Hotels.Find(id);
            if (lokoja != null)
            {
                _context.Hotels.Remove(lokoja);
                _context.SaveChanges();
                return Ok("Successfully Deleted lokaja");

            }
             return NotFound();
        }    
    }
         
}
