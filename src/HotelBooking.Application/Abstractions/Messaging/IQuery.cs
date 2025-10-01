using HotelBooking.Domain.Shared;
using MediatR;

namespace HotelBooking.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}