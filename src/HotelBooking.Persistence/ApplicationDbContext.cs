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
		optionsBuilder.UseSqlServer(@"Server=DESKTOP-S3I99RT\SQLEXPRESS;Database=hotel_booking;Trusted_Connection=True;TrustServerCertificate=True; ");
	}
}
