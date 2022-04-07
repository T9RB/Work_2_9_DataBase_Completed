using System;
using System.Collections.Generic;

namespace lr29
{
    public partial class Task
    {
        public int Taskid { get; set; }
        public string NameTask { get; set; } = null!;
        public string DescriptionTask { get; set; } = null!;
        public DateTime DatePub { get; set; }
        public int CreatorId { get; set; }
        public int AcceptorId { get; set; }
        public int Statusid { get; set; }

        public virtual User Acceptor { get; set; } = null!;
        public virtual User Creator { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
