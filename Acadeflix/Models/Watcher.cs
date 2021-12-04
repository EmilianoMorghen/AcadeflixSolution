using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Watcher
    {
        public Watcher()
        {
            Openeds = new HashSet<Opened>();
            Preferreds = new HashSet<Preferred>();
        }

        public int PkIdWatcher { get; set; }
        public string Nickname { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Opened> Openeds { get; set; }
        public virtual ICollection<Preferred> Preferreds { get; set; }
    }
}
