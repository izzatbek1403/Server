using AutoMapper;
using Server.Application.Common.DTOs.Inventory;
using Server.Domain.Entities.Inventory;

namespace Server.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Good Entity <-> GoodDto mapping
            CreateMap<Good, GoodDto>()
                .ForMember(dest => dest.DateAdd, opt => opt.MapFrom(src => src.DATE_ADD)) // Entity field'larını DTO'ya map et
                .ForMember(dest => dest.DateUpdate, opt => opt.MapFrom(src => src.DATE_UPDATE))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IS_DELETED))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group != null ? src.Group.NAME : string.Empty))
                .ReverseMap() // Ters yönde de mapping yap
                .ForMember(dest => dest.DATE_ADD, opt => opt.MapFrom(src => src.DateAdd))
                .ForMember(dest => dest.DATE_UPDATE, opt => opt.MapFrom(src => src.DateUpdate))
                .ForMember(dest => dest.IS_DELETED, opt => opt.MapFrom(src => src.IsDeleted));

            // CreateGoodDto -> Good mapping
            CreateMap<CreateGoodDto, Good>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => Guid.CreateVersion7().ToString())) // Yeni GUID oluştur
                .ForMember(dest => dest.NAME, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.BARCODE, opt => opt.MapFrom(src => src.Barcode ?? string.Empty))
                .ForMember(dest => dest.BARCODES, opt => opt.MapFrom(src => src.Barcodes ?? string.Empty))
                .ForMember(dest => dest.DESCRIPTION, opt => opt.MapFrom(src => src.Description ?? string.Empty))
                .ForMember(dest => dest.GROUP_UID, opt => opt.MapFrom(src => src.GroupUID))
                .ForMember(dest => dest.SET_STATUS, opt => opt.MapFrom(src => src.SetStatus))
                .ForMember(dest => dest.DATE_ADD, opt => opt.MapFrom(src => DateTime.UtcNow)) // Şu anki zaman
                .ForMember(dest => dest.DATE_UPDATE, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IS_DELETED, opt => opt.MapFrom(src => false)); // Yeni kayıt silinmemiş
        }
    }
}
