using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBookingHotel.Data
{
    public class Room
    {
        public int Id { get; set; }
	    public int IdType { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Addtional { get; set; }
        public string Alias { get; set; }
        public string ImageRoom { get; set; }
        public decimal Pirce { get; set; }
        public string Note { get; set; }
    }
}
