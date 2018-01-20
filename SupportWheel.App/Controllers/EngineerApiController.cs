using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Services.Repositories;

namespace SupportWheel.App.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class EngineerApiController : ApiController
    {
        /// <summary>
        /// The engineer repository
        /// </summary>
        private readonly IEngineerRepository _engineerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineerApiController"/> class.
        /// </summary>
        /// <param name="engineerRepository">The engineer repository.</param>
        public EngineerApiController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
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
