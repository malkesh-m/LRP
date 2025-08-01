using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class GLTransactionExcelModel
    {
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ID_FIELD { get; set; }
        public string ACCT { get; set; }
        public string DESCR { get; set; }
        public string BATNBR { get; set; }
        public string CPNYID { get; set; }
        public string FISCYR { get; set; }
        public string ID { get; set; }
        public string REFNBR { get; set; }
        public string DOCNBR { get; set; }
        public DateTime? TRANDATE { get; set; }
        public string TRANDESC { get; set; }
        public string LM2_DESCRIPTION { get; set; }
        public string FINAL_ID { get; set; }
        public string LM2_CODE { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public double? AMOUNT { get; set; }
        public string MASTERID { get; set; }
        public DateTime? CHECKDATE { get; set; }
        public string CHECKNO { get; set; }
        public string LM2_FISCYR { get; set; }
        public int? OldRecordID { get; set; }
        public string LM2_FISCYR_ACCT { get; set; }
        public string Description { get; set; }
    }
}
