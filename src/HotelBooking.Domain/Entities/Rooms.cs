using HotelBooking.Domain.Primitives;
using System.Diagnostics;
namespace HotelBooking.Domain.Entities
{
	public class  Rooms : EntityX
	{
		public Rooms(int id, int roomTypeId, int roomNumber,int adultMaxCapacity,
		int childernMaxCapacity)
			: base(id)
		{
			Id = id;
			RoomTypeId = roomTypeId;
			RoomNumber = roomNumber;
			AdultMaxCapacity = adultMaxCapacity;
			ChildernMaxCapacity = childernMaxCapacity;
		}

		public new int Id { get; set; }
		public int HotelId { get; set; }
		public Hotel Hotel { get; set; }
		public int RoomTypeId { get; set; }
		public int RoomNumber { get; set; }
		public int AdultMaxCapacity { get; set; }
		public int ChildernMaxCapacity { get; set; }
	}
}
