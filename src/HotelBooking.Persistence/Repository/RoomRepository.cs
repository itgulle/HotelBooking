using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Persistence.Repository;

internal sealed class RoomRepository : IRoomRepository
{
	public void Add(RoomsBooking member)
	{

	}

	public async Task<Rooms?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		using (var context = new ApplicationDbContext())
		{
			var query = context.Rooms.Where(s => s.Id >= id);
			return await query
				.FirstOrDefaultAsync(cancellationToken);
		}
	}

	public async Task<Rooms?> GetRoomsByDateAndCapacityAsync(DateTime checkindate, DateTime checkoutdate,
		int numberOfAdults, int numberOfChildern, CancellationToken cancellationToken = default)
	{
		List<Rooms?>? rooms = null;
		Rooms result = null;
		using (var context = new ApplicationDbContext())
		{
			var query = context.Rooms.Where(s => s.AdultMaxCapacity >= numberOfAdults
			&& s.ChildernMaxCapacity >= numberOfChildern);
			rooms = [.. query];
		}
		foreach (var room in rooms)
		{
			using (var context = new ApplicationDbContext())
			{
				var query = context.RoomsBooking.Where(s => s.CheckInDate >= checkindate &&
				s.CheckOutDate >= checkindate && s.RoomId == room.Id);

				if (!query.Any())
				{
					result = room;
					break;
				}
			}
		}
		return result;
	}
}