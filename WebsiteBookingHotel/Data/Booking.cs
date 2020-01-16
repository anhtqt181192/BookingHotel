using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBookingHotel.Data
{
    public class Booking
    {
        public int Id { get; set; }
	    public int IdRoom { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string AddressCustomer { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int TotalCustomer { get; set; }
        public string Note { get; set; }
    }
}
