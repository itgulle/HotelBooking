using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Members.Commands.CreateMember;

public sealed record SeedResetCommand() : ICommand;