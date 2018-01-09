using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Services.Repositories;
using BL.Services.Rules;
using SupportWheel.App.Helper;

namespace SupportWheel.App.Controllers
{
    public class WheelApiController : ApiController
    {

        private readonly ITaskRepository _taskRepository;
        private readonly ITaskRule _taskRule;
        public WheelApiController(ITaskRepository taskRepository, ITaskRule taskRule)
        {
            _taskRepository = taskRepository;
            _taskRule = taskRule;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = new List<object>();

            foreach (var item in _taskRepository.GetAll())
            {
                DayHelper.DayByNumber = item.EngineerId.ToString();
                data.Add(new { Id = item.Engineer.Name, Name = DayHelper.DayByNumber });
            }

            return Ok(data);
        }
        [HttpGet]
        [Route("api/WheelApi/GetRules")]
        public IHttpActionResult GetRules()
        {


            var data = new List<object>();

            var enginners = _taskRule.UpdateShiftToEmployee();

            foreach (var item in enginners)
            {
                DayHelper.DayByNumber = item.Day.ToString();
                data.Add(new { Name = item.Engineer.Name, Day = DayHelper.DayByNumber, numberDay= item.Day });
            }

            return Ok(data);
        }
    }
}
