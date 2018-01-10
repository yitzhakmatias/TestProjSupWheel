using System.Collections.Generic;
using System.Web.Http;
using BL.Services.Rules;
using SupportWheel.App.Helper;

namespace SupportWheel.App.Controllers
{
    public class WheelApiController : ApiController
    {
        private readonly ITaskRule _taskRule;
        public WheelApiController(ITaskRule taskRule)
        {
            _taskRule = taskRule;
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
                DayHelper.Week = item.Shift.ShiftId.ToString();
                data.Add(new { Name = item.Engineer.Name, Day = DayHelper.DayByNumber, numberDay= item.Day , week = DayHelper.Week });
            }

            return Ok(data);
        }
    }
}
