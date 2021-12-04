using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Preferred
    {
        public int PkIdPreferred { get; set; }
        public int FkIdContent { get; set; }
        public int FkIdWatcher { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
        public virtual Watcher FkIdWatcherNavigation { get; set; }
    }
}
