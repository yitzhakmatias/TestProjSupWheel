namespace DAL.DataContext.Ctx
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Engineer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Engineer()
        {
            TaskEngineers = new HashSet<TaskEngineer>();
        }

        public int EngineerId { get; set; }

        public string Name { get; set; }

        public int TaskId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskEngineer> TaskEngineers { get; set; }
    }
}
