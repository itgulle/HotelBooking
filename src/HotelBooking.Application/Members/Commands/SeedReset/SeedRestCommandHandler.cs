using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Shared;
using static HotelBooking.Domain.Errors.DomainErrors;

namespace HotelBooking.Application.Members.Commands.CreateMember;

internal sealed class SeedRestCommandHandler : ICommandHandler<SeedResetCommand>
{
	private readonly IBookingRepository _bookingRepository;
	private readonly IRoomRepository _roomRepository;
	private readonly IUnitOfWork _unitOfWork;

	public SeedRestCommandHandler(
			IBookingRepository bookingRepository,
			IRoomRepository roomRepository,
			IUnitOfWork unitOfWork)
	{
		_bookingRepository = bookingRepository;
		_roomRepository = roomRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(SeedResetCommand request, CancellationToken cancellationToken)
	{
		var flush = await _bookingRepository.Flush();
		if (!flush)
		{
			return Result.Failure(RoomBooking.Flush);			
		}
		return Result.Success();
	}
}