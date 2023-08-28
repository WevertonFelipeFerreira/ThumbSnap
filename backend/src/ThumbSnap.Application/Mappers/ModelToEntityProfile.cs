using AutoMapper;
using ThumbSnap.Application.Commands.CreateVideoInformation;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Application.Mappers
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region Video Information
            CreateMap<CreateVideoInformationCommand, VideoInformation>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Width, opt => opt.Ignore())
                .ForMember(x => x.Height, opt => opt.Ignore())
                .ForMember(x => x.StoryboardProcessingStatus, opt => opt.Ignore())
                .ForMember(x => x.Snaps, opt => opt.Ignore())
                .ForMember(x => x.Duration, opt => opt.Ignore())
                .ForMember(x => x.Size, opt => opt.Ignore());
            #endregion
        }
    }
}
