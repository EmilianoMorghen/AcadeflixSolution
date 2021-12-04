using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Cast
    {
        public int PkIdCast { get; set; }
        public int? FkIdCredit { get; set; }
        public int? FkIdContent { get; set; }
        public int? FkIdRole { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
        public virtual Credit FkIdCreditNavigation { get; set; }
        public virtual Role FkIdRoleNavigation { get; set; }
    }
}
