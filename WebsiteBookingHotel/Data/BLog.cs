using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBookingHotel.Data
{
    public class BLog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Addtional { get; set; }
        public string Alias { get; set; }
        public string HTML { get; set; }
        public string Tag { get; set; }
        public DateTime DateCreate { get; set; }
        public string Note { get; set; }
    }
}
