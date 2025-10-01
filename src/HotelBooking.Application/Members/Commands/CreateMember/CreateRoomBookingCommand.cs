using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Members.Commands.CreateMember;

public sealed record CreateRoomBookingCommand(
    int RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    int NumberOfAdults,
    int NumberOfChildern,
		int roomId) : ICommand;