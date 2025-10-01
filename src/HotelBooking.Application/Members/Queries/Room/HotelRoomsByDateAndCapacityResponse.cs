namespace HotelBooking.Application.Members.Queries.Room
{
	public sealed record HotelRoomsByDateAndCapacityResponse(int Id,
			int HotelId, int RoomTypeId, int RoomNumber);	
}
