namespace Server.Application.Common.DTOs.Common
{
    public class ApiResponseDto<T>
    {
        public bool IsSuccess { get; set; } = true; // İşlem başarı durumu
        public string Message { get; set; } = string.Empty; // İşlem mesajı
        public T? Data { get; set; } // Dönen veri (generic)
        public List<string> Errors { get; set; } = new(); // Hata listesi
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // İşlem zamanı

        // Factory Methods
        public static ApiResponseDto<T> Success(T data, string message = "İşlem başarılı")
        {
            return new ApiResponseDto<T>
            {
                IsSuccess = true, // Başarılı işlem
                Message = message, // Başarı mesajı
                Data = data, // Dönen veri
                Errors = new() // Hata yok
            };
        }

        public static ApiResponseDto<T> Failure(string message, List<string>? errors = null)
        {
            return new ApiResponseDto<T>
            {
                IsSuccess = false, // Başarısız işlem
                Message = message, // Hata mesajı
                Data = default, // Veri yok
                Errors = errors ?? new() // Hata listesi
            };
        }
    }
}
