using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Repositories;

public interface IBookingRepository
{
    Task<RoomsBooking?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
		bool GetRoomAvailability(int roomId, DateTime checkInDate,
					DateTime checkOutDate, CancellationToken cancellationToken = default);
		void Add(RoomsBooking member);
}