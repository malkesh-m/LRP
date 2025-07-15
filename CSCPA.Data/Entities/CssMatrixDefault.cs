using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssMatrixDefault
    {
        public string AccountMask { get; set; }
        public int? Accatnum { get; set; }
        public int? Year { get; set; }
        public string RowNoDmg { get; set; }
        public string Heading1Dmg { get; set; }
        public string Heading2Dmg { get; set; }
        public string Heading3Dmg { get; set; }
        public string RowDescriptionDmg { get; set; }
        public string DepartmentDmg { get; set; }
        public string RowNoGp { get; set; }
        public string DescriptionGp { get; set; }
        public string DepartmentGp { get; set; }
        public string ReportGroupHeaderGp { get; set; }
        public int DexRowId { get; set; }
        public string CompanyCode { get; set; }
    }
}
