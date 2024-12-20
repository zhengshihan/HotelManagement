using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAHotel.Service
{
    public interface IHotelService
    {
        List<HotelRes> GetHotels();
        HotelRes GetHotel(int id);
    }
    
}
