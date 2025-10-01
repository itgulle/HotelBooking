using HotelBooking.Application.Abstractions.Messaging;

namespace HotelBooking.Application.Members.Queries.Hotel;

public sealed record GetHotelByNameQuery(string Name) : IQuery<HotelResponse>;