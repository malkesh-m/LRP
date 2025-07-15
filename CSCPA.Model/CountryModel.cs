using System;

namespace CSCPA.Model
{
    public class CountryListModel
    {
        public Guid ObjectUID { get; set; }
        public string Name { get; set; }
    }
    public class CountryAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
