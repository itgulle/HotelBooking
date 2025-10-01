using HotelBooking.Application.Abstractions.Messaging;

namespace HotelBooking.Application.Members.Queries.Room
{
	public sealed record GetHotelRoomsByDateAndCapacityQuery(DateTime checkindate,
			DateTime checkoutdate, int numberOfAdults, int numberOfChildern) : IQuery<HotelRoomsByDateAndCapacityResponse>;

}
