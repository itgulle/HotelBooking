using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Repositories;

public interface IHotelRepository
{
    Task<Hotel?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}