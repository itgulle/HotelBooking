using HotelBooking.Application.Abstractions.Messaging;

namespace HotelBooking.Application.Members.Queries.Booking;

public sealed record GetHotelBookingByIdQuery(int id) : IQuery<HotelBookingResponse>;