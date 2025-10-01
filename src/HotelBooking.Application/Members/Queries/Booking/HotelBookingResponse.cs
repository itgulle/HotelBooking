namespace HotelBooking.Application.Members.Queries.Booking
{
	public sealed record HotelBookingResponse(int id, int roomId, DateTime checkInDate, DateTime checkOutDate,
		int numberOfAdults, int numberOfChildern);
}