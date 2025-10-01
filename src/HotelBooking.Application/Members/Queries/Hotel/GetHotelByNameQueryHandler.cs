using HotelBooking.Application.Abstractions.Messaging;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Shared;

namespace HotelBooking.Application.Members.Queries.Hotel;

internal sealed class GetHotelByNameQueryHandler
		: IQueryHandler<GetHotelByNameQuery, HotelResponse>
{
	private readonly IHotelRepository _memberRepository;

	public GetHotelByNameQueryHandler(IHotelRepository memberRepository)
	{
		_memberRepository = memberRepository;
	}

	public async Task<Result<HotelResponse>> Handle(
			GetHotelByNameQuery request,
			CancellationToken cancellationToken)
	{
		var member = await _memberRepository.GetByNameAsync(
				request.Name,
				cancellationToken);

		if (member is null)
		{
			return Result.Failure<HotelResponse>(new Error(
					"Hotel.NotFound",
					$"The hotel with Name : {request.Name} was not found"));
		}

		var response = new HotelResponse(member.Name, member.Address);

		return response;
	}
}