using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Models
{
    public class RoomModels
    {
        public RoomModels() { }

        public RoomModels(Room room)
        {
            Id = room.Id;
            Title = room.Title;
            Descriptions = room.Descriptions;
            Addtional = room.Addtional;
            ImageRoom = room.ImageRoom;
            Pirce = room.Pirce;
            Note = room.Note;
        }

        public Room GetRoom()
        {
            Room room = new Room();
            room.Id = Id;
            room.Title= Title;
            room.Descriptions= Descriptions;
            room.Addtional= Addtional;
            room.ImageRoom= ImageRoom;
            room.Pirce= Pirce;
            room.Note = Note;
            return room;
        }

        public int Id { get; set; }
        public int IdType { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Addtional { get; set; }
        public string ImageRoom { get; set; }
        public decimal Pirce { get; set; }
        public string Note { get; set; }
    }
}
