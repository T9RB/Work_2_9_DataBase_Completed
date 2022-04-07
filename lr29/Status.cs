using System;
using System.Collections.Generic;

namespace lr29
{
    public partial class Status
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }

        public int Statusid { get; set; }
        public string NameStatus { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
