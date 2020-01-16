using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBookingHotel.Data
{
    public class WebsiteInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
	    public string Logo { get; set; }
	    public string Email { get; set; }
	    public string AddressWebsite { get; set; }
	    public string MapLatLon { get; set; }
	    public string PhoneNumber { get; set; }
	    public string DateWork { get; set; }
	    public string TimeWork { get; set; }
	    public string Descriptions { get; set; }
	    public string Slogan { get; set; }
	    public string Tag { get; set; }
	    public DateTime DateCreate { get; set; }
        public string SocicalLink { get; set; }
	    public string Note { get; set; }
    }
}
