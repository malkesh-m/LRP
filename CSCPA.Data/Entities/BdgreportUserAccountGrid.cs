using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportUserAccountGrid
    {
        public string UserAccount { get; set; }
        public Guid BdgreportId { get; set; }
        public Guid ObjectUid { get; set; }
    }
}
