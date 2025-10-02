using System.Net;
using System.Xml.Linq;

namespace HotelBooking.Application.Members.Queries.Room
{
	public sealed record HotelRoomsByDateAndCapacityResponse(int Id,
			HotelRoomResponse Hotel, int RoomTypeId, int RoomNumber, string RoomType);	
	public sealed record HotelRoomResponse(int id, string Name, string Address);
}
