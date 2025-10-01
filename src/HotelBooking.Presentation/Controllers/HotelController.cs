using HotelBooking.Application.Members.Commands.CreateMember;
using HotelBooking.Application.Members.Queries.Booking;
using HotelBooking.Application.Members.Queries.Hotel;
using HotelBooking.Application.Members.Queries.Room;
using HotelBooking.Domain.Shared;
using HotelBooking.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Presentation.Controllers;

[Route("api/hotel")]
public sealed class HotelController : ApiController
{
    public HotelController(ISender sender)
        : base(sender)
    {
    }

	  [HttpGet("name/{name}")]
	  public async Task<IActionResult> GetHotelByName(string name, CancellationToken cancellationToken)
	  {
		  var query = new GetHotelByNameQuery(name);

		  Result<HotelResponse> response = await Sender.Send(query, cancellationToken);

		  return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
	  }
		[HttpGet("room/checkindate/{checkindate}/checkoutdate/{checkoutdate}/numberofadults/{numberOfAdults}/numberofchildren/{numberOfChildern}")]
		public async Task<IActionResult> GetHotelBooking(DateTime checkindate,
			DateTime checkoutdate, int numberOfAdults, int numberOfChildern, CancellationToken cancellationToken)
		{
			var query = new GetHotelRoomsByDateAndCapacityQuery(checkindate,checkoutdate, numberOfAdults, numberOfChildern);

			Result<HotelRoomsByDateAndCapacityResponse> response = await Sender.Send(query, cancellationToken);

			return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
		}
		[HttpPost("booking/room/checkindate/{checkindate}checkoutdate/{checkoutdate}/numberofadults/{numberOfAdults}/numberofchildrens/{numberOfChildern}roomid/{roomId}")]
		public async Task<IActionResult> BookRoom(DateTime checkindate, DateTime checkoutdate,
			int numberOfAdults, int numberOfChildern, int roomId, CancellationToken cancellationToken)
		{
			var command = new CreateRoomBookingCommand(roomId, checkindate, checkoutdate, numberOfAdults, numberOfChildern, roomId);

			var result = await Sender.Send(command, cancellationToken);

			return result.IsSuccess ? Ok("Booking successfull..") : BadRequest(result.Error);
		}
	[HttpGet("booking/id/{id}")]
	  public async Task<IActionResult> GetHotelBooking(int id, CancellationToken cancellationToken)
	  {
		  var query = new GetHotelBookingByIdQuery(id);

		  Result<HotelBookingResponse> response = await Sender.Send(query, cancellationToken);

		  return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
	  }

}