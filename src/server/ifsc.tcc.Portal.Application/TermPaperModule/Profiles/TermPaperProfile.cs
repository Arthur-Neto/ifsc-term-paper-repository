using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Profiles
{
    public class TermPaperProfile : Profile
    {
        public TermPaperProfile()
        {
            CreateMap<TermPaperAddCommand, TermPaper>()
                .ForMember(tp => tp.Title, tp => tp.MapFrom(cmd => cmd.Title))
                .ForMember(tp => tp.DateBegin, tp => tp.MapFrom(cmd => cmd.DateBegin))
                .ForMember(tp => tp.DateEnd, tp => tp.MapFrom(cmd => cmd.DateEnd))
                .ForMember(tp => tp.FileName, tp => tp.Ignore())
                .ForMember(tp => tp.Course, tp => tp.Ignore())
                .ForMember(tp => tp.CourseID, tp => tp.Ignore())
                .ForMember(tp => tp.ID, tp => tp.Ignore())
                .ForMember(tp => tp.TermPaperAdvisors, tp => tp.Ignore())
                .ForMember(tp => tp.TermPaperKeywords, tp => tp.Ignore());
        }
    }
}
