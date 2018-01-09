using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Services.Repositories;

namespace SupportWheel.App.Controllers
{
    public class EngineerApiController : ApiController
    {
        private readonly IEngineerRepository _engineerRepository;

        public EngineerApiController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = new List<object>();

            foreach (var item in _engineerRepository.GetAll())
            {
                data.Add(new {Id = item.EngineerId, Name = item.Name});
            }

            return Ok(data);
        }

    }
}
