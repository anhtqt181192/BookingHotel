using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Models
{
    public class BookingModels
    {
        public BookingModels(Booking booking)
        {
           Id = booking.Id;
           IdRoom = booking.IdRoom;
           Email = booking.Email;
           PhoneNumber = booking.PhoneNumber;
           Name = booking.Name;
           AddressCustomer = booking.AddressCustomer;
           FromDate = booking.FromDate == null ? "" : booking.FromDate.ToString("dd/MM/yyyy");
           ToDate = booking.ToDate == null ? "" : booking.ToDate.ToString("dd/MM/yyyy");
           Adults = booking.Adults;
           Children = booking.Children;
           TotalCustomer = booking.TotalCustomer;
           Note = booking.Note;
        }

        public int Id { get; set; }
        public int IdRoom { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string AddressCustomer { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int TotalCustomer { get; set; }
        public string Note { get; set; }
    }
}
