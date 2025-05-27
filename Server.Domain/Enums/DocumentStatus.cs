namespace Server.Domain.Enums
{
    public enum DocumentStatus
    {
        None = 0,           // Durumu atanmamış / bilinmeyen
        Draft = 1,          // Taslak - henüz işlemeye alınmamış
        Open = 2,           // Açık - işleme alınmış ve aktif belge
        Close = 3,          // Kapatılmış - işlemi tamamlanmış
        NoClose = 4         // Kapanmayacak - özel süreçli belge
    }
}
