using HotelBooking.Domain.Primitives;

namespace HotelBooking.Domain.Entities;

public  class Hotel : EntityX
{
    public Hotel(int id, string name, string address)
				: base(id)
    {
        Id = id;
        Name = name;
		    Address = address;
		    this.Rooms = new HashSet<Rooms>();
	}

    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }
  	public virtual ICollection<Rooms> Rooms { get; set; }
}