using AutoMapper;
using SPAHotel.Model.Entities;
using SPAHotel.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPAHotel.Service
{
    
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Hotel.json");

        public HotelService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public HotelRes GetHotel(int id)
        {
            List<Hotel> res = new List<Hotel>();
            res = LoadHotelsFromJson();
            var hotel = res.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                throw new HotelNotFoundException($"Hotel with ID {id} not found.");
            }
            return _mapper.Map<HotelRes>(hotel);

        }

        public List<HotelRes> GetHotels()
        {
            List<Hotel> res = new List<Hotel>();
            res = LoadHotelsFromJson();
            return _mapper.Map<List<HotelRes>>(res);
        }
        private List<Hotel> LoadHotelsFromJson()
        {
            try
            {
                if (!File.Exists(_jsonFilePath))
                {
                    throw new FileNotFoundException($"The file {_jsonFilePath} was not found.");
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                // handle file not found exception
                throw fnfEx;
            }
            try
            {
                using (var stream = new FileStream(_jsonFilePath, FileMode.Open, FileAccess.Read))
                {
                    var hotels = JsonSerializer.Deserialize<List<Hotel>>(stream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return hotels;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("An unexpected error occurred while loading the hotel data.", ex);
            }
            
        }
    }
}
