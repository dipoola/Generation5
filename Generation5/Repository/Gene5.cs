using Generation5.Data;
using Generation5.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Generation5.Repository
{
    public class Gene5 : IGene5
    {
         private readonly AppDbContext _appDbContext;

        public Gene5(AppDbContext _osogbo)
        {
            _appDbContext = _osogbo;
        }
        public async Task<HotelDto> AddHotel(HotelDto Dto)
        {
            Hotel hotel = new Hotel();
            {
               hotel.Id = Dto.Id;
                hotel.Name = Dto.Name;  
                hotel.Description = Dto.Description;    
                hotel.Location = Dto.Location;  
            };
            _appDbContext.Hotels.Add(hotel);
            await _appDbContext.SaveChangesAsync();
            return Dto;
        }

        public async Task<string> DeleteHotel(int id)
        {
           var lagos=  _appDbContext.Hotels.FirstOrDefault(x=> x.Id == id);
            if (lagos != null)
            {
                _appDbContext.Hotels.Remove(lagos);
                await _appDbContext.SaveChangesAsync();
                return ("Deleted succesfully");
            }
            return null;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
           var yetty = _appDbContext.Hotels.FirstOrDefault(y => y.Id == id);
            if (yetty!= null)
            {
                return yetty;
            }

            return null;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            await _appDbContext.SaveChangesAsync();
            return _appDbContext.Hotels.ToList();
        }

        public async Task<HotelDto> UpdateHotel(int id, HotelDto Hotel)
        {
            var Nov = await _appDbContext.Hotels.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Nov != null)
            {
                return null;
            }
            
             Nov.Description = Hotel.Description;   
             Nov.Name = Hotel.Name;  
             Nov.Location = Hotel.Location;
             Nov.Id = Hotel.Id;
            _appDbContext.SaveChanges();

            var updatedNov = new HotelDto
            {
                
                Name = Nov.Name,
                Description = Nov.Description,  
                Location = Nov.Location,    
                Id = Nov.Id,  

            };
                return updatedNov;

        
        }



    }
}
