using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Logic.DTOs;
using Web_UI.

namespace Web_UI.Controllers
{
    public class HotelController : ApiController
    {
        IMapper HotelControllerMapper = new MapperConfiguration(cfg =>
            {
            cfg.CreateMap<HotelDTO, Hotel>();
            cfg.CreateMap<HotelRoomDTO, HotelRoom>();
            cfg.CreateMap<Hotel, HotelDTO>();
            cfg.CreateMap<HotelRoom, HotelRoomDTO>();
        }).CreateMapper();
            this.UoW = UoW;
        // GET api/<controller>
        public IEnumerable<> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}