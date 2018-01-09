using System.Collections.Generic;

namespace DAL.DataContext
{
    public class Engineer
    {
        public int EngineerId { get; set; }
        public string Name { get; set; }

        public int TaskId { get; set; }
        public virtual ICollection<TaskEngineer> Tasks { get; set; }
    }
}
