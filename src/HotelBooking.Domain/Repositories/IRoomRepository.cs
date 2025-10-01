using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Repositories;

public interface IRoomRepository
{
	Task<Rooms?> GetRoomsByDateAndCapacityAsync(DateTime checkindate,
			DateTime checkoutdate, int numberOfAdults, int numberOfChildern, 
			CancellationToken cancellationToken = default);

	Task<Rooms?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	void Add(RoomsBooking member);
}