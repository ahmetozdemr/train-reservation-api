using System.Reflection;
using TrenRezervasyonu.Models;

namespace TrenRezervasyonu.Services
{
    public class ReservationService : IReservationService
    {
        public TrenReservationResponseDto  CreateReservation(TrainReservationDto model)
        {

            var vagonlar = model.Tren.Vagonlar;
            var kisilerFarkliVagonlaraYerlestirilebilir = model.KisilerFarkliVagonlaraYerlestirilebilir;

            var rezervasyonYapilacakKisiSayisi = model.RezervasyonYapilacakKisiSayisi;

            var result = new TrenReservationResponseDto();

            if (kisilerFarkliVagonlaraYerlestirilebilir)
            {
                for (var i = 0; i < vagonlar.Count; i++)
                {

                    int bosYer = (int)Math.Ceiling((vagonlar[i].Kapasite * (0.70) - vagonlar[i].DoluKoltukAdet));

                    if (rezervasyonYapilacakKisiSayisi <= bosYer)
                    {

                        var newSeatDetail = new SeatDetail()
                        {
                            VagonAdi = vagonlar[i].Ad,
                            KisiSayisi = rezervasyonYapilacakKisiSayisi
                        };
                        result.YerlesimAyrinti.Add(newSeatDetail);
                        result.RezervasyonYapilabilir = true;
                        rezervasyonYapilacakKisiSayisi -= bosYer;
                        break;

                    }
                    else
                    {
                        var newSeatDetail = new SeatDetail()
                        {
                            VagonAdi = vagonlar[i].Ad,
                            KisiSayisi = bosYer
                        };
                        result.YerlesimAyrinti.Add(newSeatDetail);
                        rezervasyonYapilacakKisiSayisi -= bosYer;
                    }
                }
                if (rezervasyonYapilacakKisiSayisi > 0)
                    result.YerlesimAyrinti = new List<SeatDetail>();

            }
            else
            {
                for (var i = 0; i < vagonlar.Count; i++)
                {

                    int bosYer = (int)Math.Ceiling((vagonlar[i].Kapasite * (0.70) - vagonlar[i].DoluKoltukAdet));

                    if (rezervasyonYapilacakKisiSayisi <= bosYer)
                    {

                        var newSeatDetail = new SeatDetail()
                        {
                            VagonAdi = vagonlar[i].Ad,
                            KisiSayisi = rezervasyonYapilacakKisiSayisi
                        };
                        result.YerlesimAyrinti.Add(newSeatDetail);
                        result.RezervasyonYapilabilir = true;
                        rezervasyonYapilacakKisiSayisi -= bosYer;
                        break;

                    }

                }
                if (rezervasyonYapilacakKisiSayisi > 0)
                    result.YerlesimAyrinti = new List<SeatDetail>();
            }
            return result;
        }
    }
}
