using System;
using System.ComponentModel.DataAnnotations;

namespace CSCPA.Model
{
    public class GridLayoutListModel
    {
        public string Id { get; set; }
        public string Layoutname { get; set; }
        public string Userid { get; set; }
        public string Gridid { get; set; }
        public string Layout { get; set; }
        public string Creator { get; set; }
        public bool? Ispublic { get; set; }

    }
    public class GridLayoutAddEditModel
    {
        public string Id { get; set; }
        public string Layoutname { get; set; }
        public string Userid { get; set; }
        public string Gridid { get; set; }
        public string Layout { get; set; }
        public string Creator { get; set; }
        public bool? Ispublic { get; set; }
    }
}
