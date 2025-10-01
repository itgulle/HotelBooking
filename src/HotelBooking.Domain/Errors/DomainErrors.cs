using HotelBooking.Domain.Shared;

namespace HotelBooking.Domain.Errors;

public static class DomainErrors
{
    public static class RoomBooking
    {
        public static readonly Error RoomAlreadyBooked = new(
          "Room.Booking.BookRoom",
          "This room is already booked for these dates.");
		    public static readonly Error RoomCapacityAdult = new(
		      "Room.Booking.Capacity",
		      "This room can not be booked for this many adults.");

		    public static readonly Error RoomCapacityChildren = new(
          "Room.Booking.Capacity",
				  "This room can not be booked for this many Childern.");		    
    }    
}