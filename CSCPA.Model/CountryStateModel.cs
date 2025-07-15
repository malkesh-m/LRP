using System;

namespace CSCPA.Model
{
    public class CountryStateListModel
    {
        public Guid ObjectUID { get; set; }
        public string Name { get; set; }
    }
    public class CountryStateAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public Guid CountryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
