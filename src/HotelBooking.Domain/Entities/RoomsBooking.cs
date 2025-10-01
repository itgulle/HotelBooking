using HotelBooking.Domain.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entities;

public sealed class RoomsBooking : EntityX
{
	public RoomsBooking(int id, int roomId, DateTime checkInDate, DateTime checkOutDate,
		int numberOfAdults, int numberOfChildern)
			: base(id)
	{
		Id = id;
		RoomId = roomId;
		CheckInDate = checkInDate;
		CheckOutDate = checkOutDate;
		NumberOfAdults = numberOfAdults;
		NumberOfChildern = numberOfChildern;
	}
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key, Column(Order = 0)]
	public new int Id { get; set; }
	public int RoomId { get; set; }
	public DateTime CheckInDate { get; set; }
	public DateTime CheckOutDate { get; set; }
	public int NumberOfAdults { get; set; }
	public int NumberOfChildern { get; set; }
}
