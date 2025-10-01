using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Persistence.Repository;

internal sealed class HotelRepository : IHotelRepository
{
	public async Task<Hotel?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {

		using (var context = new ApplicationDbContext())
		{
			var query = context.Hotel.Where(s => s.Name.ToLower() == name.ToLower());
			return await query
				.FirstOrDefaultAsync(cancellationToken);
		}
	}
}