using TrenRezervasyonu.Models;

namespace TrenRezervasyonu.Services
{
    public interface IReservationService
    {
        TrenReservationResponseDto CreateReservation(TrainReservationDto model);
    }
}
