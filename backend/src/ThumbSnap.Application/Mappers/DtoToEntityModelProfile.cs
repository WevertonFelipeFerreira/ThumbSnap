using AutoMapper;
using ThumbSnap.Domain.DTOs;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Application.Mappers
{
    public class DtoToEntityModelProfile : Profile
    {
        public DtoToEntityModelProfile()
        {
            #region StoryboardSnap
            CreateMap<ImageDto, StoryboardSnap>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.VideoId, opt => opt.Ignore())
                .ForMember(x => x.VideoInformation, opt => opt.Ignore())
                .ForMember(x => x.Path, opt => opt.Ignore())
                .ForMember(x => x.Size, opt => opt.MapFrom(y => y.Size))
                .ForMember(x => x.Extension, opt => opt.MapFrom(y => y.Extension))
                .ForMember(x => x.Time, opt => opt.MapFrom(y => y.Time));

            #endregion
        }
    }
}
