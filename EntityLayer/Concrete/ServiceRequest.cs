using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ServiceRequest
	{
        public int ServiceRequestID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public string RequestService { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
