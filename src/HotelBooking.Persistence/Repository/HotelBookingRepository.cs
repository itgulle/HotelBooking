using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Persistence.Repository;

internal sealed class HotelBookingRepository : IBookingRepository
{
	public void Add(RoomsBooking member)
	{
		using (var context = new ApplicationDbContext())
		{
			context.Set<RoomsBooking>().Add(member);
			context.SaveChanges();
		}
	}
	public async Task<RoomsBooking?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		using (var context = new ApplicationDbContext())
		{
			var query = context.RoomsBooking.Where(s => s.Id == id);
			return await query
				.FirstOrDefaultAsync(cancellationToken);
		}
	}

	public bool GetRoomAvailability(int roomId, DateTime checkInDate,
			DateTime checkOutDate, CancellationToken cancellationToken = default)
	{
		using (var context = new ApplicationDbContext())
		{
			var query = context.RoomsBooking.Where(
				s => s.RoomId == roomId &&
				s.CheckInDate >= checkInDate &&
				s.CheckOutDate <= checkOutDate);
			return query.Any();
		}
	}

}