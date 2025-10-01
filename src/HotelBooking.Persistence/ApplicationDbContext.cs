using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Persistence;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<Hotel> Hotel { get; set; }
	public DbSet<RoomsBooking> RoomsBooking { get; set; }
	public DbSet<Rooms> Rooms { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=tcp:hotelbookingsql.database.windows.net,1433;Initial Catalog=bookhotel;Persist Security Info=False;User ID=hotel;Password=DWp876#HK43;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
	}
}
