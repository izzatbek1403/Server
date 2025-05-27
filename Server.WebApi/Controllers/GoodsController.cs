using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Common.DTOs.Common;
using Server.Application.Common.DTOs.Inventory;
using Server.Application.Features.Goods.Commands.CreateGood;

namespace Server.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly IMediator _mediator; // MediatR pattern için

        public GoodsController(IMediator mediator)
        {
            _mediator = mediator; // Dependency injection ile mediator
        }

        /// <summary>
        /// Yeni ürün oluşturur
        /// </summary>
        /// <param name="createGoodDto">Ürün bilgileri</param>
        /// <returns>Oluşturulan ürün bilgisi</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseDto<GoodDto>), 200)] // Swagger için response type
        [ProducesResponseType(typeof(ApiResponseDto<GoodDto>), 400)] // Hata response type
        public async Task<IActionResult> CreateGood([FromBody] CreateGoodDto createGoodDto)
        {
            if (!ModelState.IsValid) // Model validation kontrolü
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList(); // Validation hatalarını topla

                return BadRequest(ApiResponseDto<GoodDto>.Failure("Validation hatası", errors)); // 400 Bad Request
            }

            var command = new CreateGoodCommand(createGoodDto); // Command oluştur
            var result = await _mediator.Send(command); // MediatR ile handler'a gönder

            if (result.IsSuccess)
                return Ok(result); // 200 OK response
            else
                return BadRequest(result); // 400 Bad Request response
        }

        /// <summary>
        /// Test endpoint - API çalışıyor mu kontrolü
        /// </summary>
        /// <returns>Test mesajı</returns>
        [HttpGet("test")]
        [ProducesResponseType(typeof(object), 200)]
        public IActionResult Test()
        {
            return Ok(new
            {
                Message = "GBS Management API çalışıyor!", // Test mesajı
                Timestamp = DateTime.UtcNow, // Şu anki zaman
                Version = "1.0.0", // API versiyonu
                Database = "Firebird bağlantısı aktif" // Veritabanı durumu
            });
        }
    }
}