namespace TrenRezervasyonu.Models
{
    public class TrenReservationResponseDto
    {
        public bool RezervasyonYapilabilir { get; set; }=false; 
        public List<SeatDetail> YerlesimAyrinti { get; set; }= new List<SeatDetail>();

    }
    public class SeatDetail
    {
        public string VagonAdi { get; set; } = string.Empty;
        public int KisiSayisi { get; set; }
    }

}
