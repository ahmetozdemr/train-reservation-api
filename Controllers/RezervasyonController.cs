using Microsoft.AspNetCore.Mvc;
using TrenRezervasyonu.Services;

namespace TrenRezervasyonu.Controllers
{
    [Route("reservation")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public RezervasyonController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost("")]
        public IActionResult ActionResult([FromBody] TrainReservationDto model)
        {
            var result = _reservationService.CreateReservation(model);
            return Ok(result);
        }
    }
}
