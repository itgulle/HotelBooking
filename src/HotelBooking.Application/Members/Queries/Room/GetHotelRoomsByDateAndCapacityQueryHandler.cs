using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Shared;

namespace HotelBooking.Application.Members.Queries.Room
{
	internal sealed class GetHotelRoomsByDateAndCapacityQueryHandler
				: IQueryHandler<GetHotelRoomsByDateAndCapacityQuery, HotelRoomsByDateAndCapacityResponse>
	{
		private readonly IRoomRepository _roomRepository;

		public GetHotelRoomsByDateAndCapacityQueryHandler(IRoomRepository roomRepository)
		{
			_roomRepository = roomRepository;
		}

		public async Task<Result<HotelRoomsByDateAndCapacityResponse>> Handle(
				GetHotelRoomsByDateAndCapacityQuery request,
				CancellationToken cancellationToken)
		{
			var member = await _roomRepository.GetRoomsByDateAndCapacityAsync(
					request.checkindate, request.checkoutdate, request.numberOfAdults, 
					request.numberOfChildern,
					cancellationToken);

			if (member is null)
			{
				return Result.Failure<HotelRoomsByDateAndCapacityResponse>(new Error(
						"Room(s) .NotFound",
						$"No Rooms available form {request.checkindate} To {request.checkoutdate}, " +
						$"for {request.numberOfAdults} adults and {request.numberOfChildern} children/"));
			}
			var hotelResponse = new HotelRoomResponse(member.Hotel.Id, member.Hotel.Name, member.Hotel.Address);
			var response = new HotelRoomsByDateAndCapacityResponse(member.Id, hotelResponse, member.RoomTypeId,
				member.RoomNumber);

			return response;
		}		
	}
}
