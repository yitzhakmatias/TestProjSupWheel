using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class TaskEngineer
    {
       // public int  TaskId { get; set; }
        [Key, Column(Order = 0)]
        public int EngineerId { get; set; }
        [Key, Column(Order = 1)]
        public int ShiftId { get; set; }

       
        public Engineer Engineers { get; set; }
        public Shift Shifts { get; set; }
        public int Day { get; set; }
    }
}
