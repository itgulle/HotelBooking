using HotelBooking.Domain.Repositories;

namespace HotelBooking.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}