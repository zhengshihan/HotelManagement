using AutoMapper;
using SPAHotel.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SPAHotel.Service.Config
{

    public class AutoMapperConfigs : Profile
    {   
        /// <summary>
        /// config mapping in the constructor
        /// </summary>
        public AutoMapperConfigs() 
        {
            CreateMap<Hotel, HotelRes>();
        }
    }
}
