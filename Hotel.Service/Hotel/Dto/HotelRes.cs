using SPAHotel.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAHotel.Service
{

    public class HotelRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public List<String> DatesOfTravel { get; set; }
        public string BoardBasis { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
