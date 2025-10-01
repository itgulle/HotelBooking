using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Shared;

namespace HotelBooking.Application.Members.Queries.Booking
{
	internal sealed class GetHotelBookingByIdQueryHandler
			: IQueryHandler<GetHotelBookingByIdQuery, HotelBookingResponse>
	{
		private readonly IBookingRepository _bookingRepository;

		public GetHotelBookingByIdQueryHandler(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		public async Task<Result<HotelBookingResponse>> Handle(
				GetHotelBookingByIdQuery request,
				CancellationToken cancellationToken)
		{
			var member = await _bookingRepository.GetByIdAsync(
					request.id,
					cancellationToken);

			if (member is null)
			{
				return Result.Failure<HotelBookingResponse>(new Error(
						"Room Booking.NotFound",
						$"Booking reference {request.id} was not found"));
			}

			var response = new HotelBookingResponse(member.Id, member.RoomId, member.CheckInDate, 
				member.CheckOutDate, member.NumberOfAdults, member.NumberOfChildern);

			return response;
		}
	}
}
