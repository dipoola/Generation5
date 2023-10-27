using Generation5.Data;
using Generation5.Models;

namespace Generation5.Repository
{
    public interface IGene5
    {
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotelById(int id);
        Task<HotelDto> AddHotel(HotelDto Dto);
        Task<HotelDto> UpdateHotel(int id, HotelDto Hotel);
        Task<String> DeleteHotel(int id);
    }
}
