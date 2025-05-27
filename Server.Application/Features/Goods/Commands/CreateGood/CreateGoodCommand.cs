using MediatR;
using Server.Application.Common.DTOs.Common;
using Server.Application.Common.DTOs.Inventory;

namespace Server.Application.Features.Goods.Commands.CreateGood
{
    public class CreateGoodCommand : IRequest<ApiResponseDto<GoodDto>>
    {
        public CreateGoodDto GoodData { get; set; } = new(); // DTO kullanarak veri transfer

        public CreateGoodCommand(CreateGoodDto goodData)
        {
            GoodData = goodData; // Constructor ile DTO'yu al
        }
    }
}
