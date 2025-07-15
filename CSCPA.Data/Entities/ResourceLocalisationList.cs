using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ResourceLocalisationList
    {
        public Guid LocalisationId { get; set; }
        public string Localisation { get; set; }
        public string Translation { get; set; }
        public string Resource { get; set; }
        public Guid? ModuleId { get; set; }
        public bool IsInactive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
