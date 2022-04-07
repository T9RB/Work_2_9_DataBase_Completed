using System;
using System.Collections.Generic;

namespace lr29
{
    public partial class User
    {
        public User()
        {
            TaskAcceptors = new HashSet<Task>();
            TaskCreators = new HashSet<Task>();
        }

        public int Userid { get; set; }
        public string FName { get; set; } = null!;
        public string SName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long NumberPhone { get; set; }

        public virtual ICollection<Task> TaskAcceptors { get; set; }
        public virtual ICollection<Task> TaskCreators { get; set; }
    }
}
