using AutoMapper;
using MediatR;
using Server.Application.Common.DTOs.Common;
using Server.Application.Common.DTOs.Inventory;
using Server.Application.Common.Interfaces;
using Server.Domain.Entities.Inventory;

namespace Server.Application.Features.Goods.Commands.CreateGood
{
    public class CreateGoodCommandHandler : IRequestHandler<CreateGoodCommand, ApiResponseDto<GoodDto>>
    {
        private readonly IApplicationDbContext _context; // Veritabanı context'i
        private readonly IMapper _mapper; // AutoMapper instance'ı

        public CreateGoodCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context; // Dependency injection ile context
            _mapper = mapper; // Dependency injection ile mapper
        }

        public async Task<ApiResponseDto<GoodDto>> Handle(CreateGoodCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // DTO'dan Entity'ye otomatik mapping
                var good = _mapper.Map<Good>(request.GoodData);

                _context.GOODS.Add(good); // Entity'yi context'e ekle
                await _context.SaveChangesAsync(cancellationToken); // Veritabanına kaydet

                // Entity'den DTO'ya otomatik mapping
                var goodDto = _mapper.Map<GoodDto>(good);

                return ApiResponseDto<GoodDto>.Success(goodDto, "Ürün başarıyla oluşturuldu."); // Başarılı response
            }
            catch (Exception ex)
            {
                return ApiResponseDto<GoodDto>.Failure($"Ürün oluşturulurken hata: {ex.Message}"); // Hata response'u
            }
        }
    }
}
