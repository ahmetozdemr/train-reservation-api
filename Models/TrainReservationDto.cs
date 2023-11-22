using System.Collections.Generic;

public class TrainReservationDto
{
    public class WagonDto
    {
        public string Ad { get; set; } = string.Empty;
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }

    public class TrainDto
    {
        public string Ad { get; set; } = string.Empty;
        public List<WagonDto> Vagonlar { get; set; } = new List<WagonDto>();
    }

    public TrainDto Tren { get; set; } = new TrainDto();
    public int RezervasyonYapilacakKisiSayisi { get; set; }
    public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
}