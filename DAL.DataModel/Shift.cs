using System.Collections.Generic;

namespace DAL.DataContext
{
    public class Shift
    {
        public Shift()
        {
            
        }
        public Shift(int i)
        {
            this.ShiftId = i;
        }
        public int ShiftId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskEngineer> Tasks { get; set; }

    }
}
