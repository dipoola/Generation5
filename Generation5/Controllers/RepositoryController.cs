using Generation5.Data;
using Generation5.Models;
using Generation5.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generation5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IGene5 _gene5services;
        public RepositoryController(IGene5 lagos)
        {
            _gene5services = lagos;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var jesus = await _gene5services.GetHotels();
            return Ok(jesus);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {

            var hp = await _gene5services.GetHotelById(id);
            return Ok(hp);
        }

        [HttpPost]
        [Route("{id:int}")]

        public async Task<IActionResult> AddHotel(HotelDto Hotel)
        {
            var osun = await _gene5services.AddHotel(Hotel);
            return Ok(osun);
        }



        [HttpPut]
        [Route("{id:int}")]

        public  async  Task<IActionResult> UpdateHotel(int id ,HotelDto Hotel)
        {
            var Edo= await _gene5services.UpdateHotel(id,Hotel);
            return Ok(Edo);

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            var Tima= await _gene5services.DeleteHotel(id); 
            return Ok(Tima);

        }
    }
    
    
}
