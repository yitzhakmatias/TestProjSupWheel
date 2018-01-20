using System.Collections.Generic;
using System.Web.Http;
using BL.Services.Rules;
using SupportWheel.App.Helper;

namespace SupportWheel.App.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class WheelApiController : ApiController
    {
        /// <summary>
        /// The task rule
        /// </summary>
        private readonly ITaskRule _taskRule;
        /// <summary>
        /// Initializes a new instance of the <see cref="WheelApiController"/> class.
        /// </summary>
        /// <param name="taskRule">The task rule.</param>
        public WheelApiController(ITaskRule taskRule)
        {
            _taskRule = taskRule;
        }

        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <returns></returns>
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
