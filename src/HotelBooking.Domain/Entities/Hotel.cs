using HotelBooking.Domain.Primitives;

namespace HotelBooking.Domain.Entities;

public sealed class Hotel : EntityX
{
    public Hotel(int id, string name, string address)
				: base(id)
    {
        Id = id;
        Name = name;
		    Address = address;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }
}