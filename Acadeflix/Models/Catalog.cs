using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Catalog
    {
        public int FkIdContent { get; set; }
        public int FkIdParent { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
        public virtual Content FkIdParentNavigation { get; set; }
    }
}
