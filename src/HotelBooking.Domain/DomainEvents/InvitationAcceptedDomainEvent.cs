using HotelBooking.Domain.Primitives;

namespace HotelBooking.Domain.DomainEvents;

public sealed record InvitationAcceptedDomainEvent(Guid InvitationId, Guid GatheringId) : IDomainEvent
{
}