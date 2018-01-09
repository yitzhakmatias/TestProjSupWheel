using System.Collections.Generic;
using DAL.DataContext.Ctx;

namespace BL.Services.Rules
{
    public interface ITaskRule
    {
        IEnumerable<TaskEngineer> UpdateShiftToEmployee();
    }
}