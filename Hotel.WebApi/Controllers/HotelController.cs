using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPAHotel.Service;
using SPAHotel.Service.Exceptions;

namespace SPAHotel.WebApi.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        public ActionResult<List<HotelRes>> GetHotels()
        {
            List<HotelRes> hotels = _hotelService.GetHotels();
            return Ok(hotels);
            
        }
        [HttpGet("{id}")]
        public ActionResult<HotelRes>GetHotel(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid hotel ID. ID must be greater than 0." });
            }
            try
            {
                HotelRes hotel = _hotelService.GetHotel(id);
                return Ok(hotel); // Return 200 OK with hotel details
            }
            catch (HotelNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });  
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }

        }

    }
}
