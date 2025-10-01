using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Shared;
using static HotelBooking.Domain.Errors.DomainErrors;

namespace HotelBooking.Application.Members.Commands.CreateMember;

internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateRoomBookingCommand>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemberCommandHandler(
				IBookingRepository bookingRepository,
				IRoomRepository roomRepository,
				IUnitOfWork unitOfWork)
    {
		    _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
		    _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateRoomBookingCommand request, CancellationToken cancellationToken)
    {
        var isRoomAvailable = _bookingRepository.GetRoomAvailability(request.roomId,
          request.CheckInDate, request.CheckOutDate,  cancellationToken);

        var checkCapacity = _roomRepository.GetByIdAsync(request.roomId).Result;
        if (request.NumberOfAdults > checkCapacity?.AdultMaxCapacity)
        {
			    return Result.Failure(RoomBooking.RoomCapacityAdult);
		    }
		    if (request.NumberOfChildern > checkCapacity?.ChildernMaxCapacity)
		    {
			    return Result.Failure(RoomBooking.RoomCapacityChildren);
		    }
		    if (!isRoomAvailable)
            {
              var member = new RoomsBooking(0, request.roomId, request.CheckInDate, request.CheckOutDate, request.NumberOfAdults, request.NumberOfChildern);

              _bookingRepository.Add(member);

              await _unitOfWork.SaveChangesAsync(cancellationToken);
              return Result.Success();
            }
		        return Result.Failure(RoomBooking.RoomAlreadyBooked);
	      }
    }