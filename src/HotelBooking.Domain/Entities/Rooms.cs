using HotelBooking.Domain.Primitives;
namespace HotelBooking.Domain.Entities
{
	public sealed class  Rooms : EntityX
	{
		public Rooms(int id, int hotelId, int roomTypeId, int roomNumber,int adultMaxCapacity,
		int childernMaxCapacity)
			: base(id)
		{
			Id = id;
			HotelId = hotelId;
			RoomTypeId = roomTypeId;
			RoomNumber = roomNumber;
			AdultMaxCapacity = adultMaxCapacity;
			ChildernMaxCapacity = childernMaxCapacity;
		}

		public new int Id { get; set; }
		public int HotelId { get; set; }
		public int RoomTypeId { get; set; }
		public int RoomNumber { get; set; }
		public int AdultMaxCapacity { get; set; }
		public int ChildernMaxCapacity { get; set; }
	}
}
