using HotelBooking.Domain.Shared;
using MediatR;

namespace HotelBooking.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
