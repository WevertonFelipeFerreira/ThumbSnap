using AutoMapper;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Models;

namespace ThumbSnap.Application.Mappers
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            #region Video Information
            CreateMap<VideoInformation, VideoInformationVM>()
                .ForMember(x=> x.StoryboardProcessingStatus, opt => opt.MapFrom(x=> x.StoryboardProcessingStatus.ToString()));
            #endregion

            #region Storyboard Snap
            CreateMap<StoryboardSnap, StoryboardSnapVM>();
            #endregion
        }
    }
}
