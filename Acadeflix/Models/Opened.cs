using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Opened
    {
        public int PkIdOpened { get; set; }
        public int FkIdWatcher { get; set; }
        public int FkIdContent { get; set; }
        public TimeSpan ViewCount { get; set; }
        public byte[] Watched { get; set; }
        public DateTime LastEdit { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
        public virtual Watcher FkIdWatcherNavigation { get; set; }
    }
}
