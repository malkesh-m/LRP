using System;

namespace CSCPA.Web.Models
{
    public class JsonWebTokenModel
    {
        public DateTime Expired { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
