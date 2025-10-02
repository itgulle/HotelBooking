using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Primitives;
using System.Diagnostics;
using System.Xml.Linq;
namespace HotelBooking.Domain.Entities
{
	public class  Rooms : EntityX
	{
		public Rooms(int id, int roomNumber,int adultMaxCapacity,
		int childernMaxCapacity)
			: base(id)
		{
			Id = id;
			RoomNumber = roomNumber;
			AdultMaxCapacity = adultMaxCapacity;
			ChildernMaxCapacity = childernMaxCapacity;
		}

		public new int Id { get; set; }
		public int HotelId { get; set; }
		public Hotel Hotel { get; set; }
		public RoomType RoomTypeId { get; set; }
		public int RoomNumber { get; set; }
		public int AdultMaxCapacity { get; set; }
		public int ChildernMaxCapacity { get; set; }
	}
}
