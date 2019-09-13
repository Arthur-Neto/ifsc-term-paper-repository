using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Application.TermPaperModule.Profiles
{
    public class TermPaperProfile : Profile
    {
        public TermPaperProfile()
        {
            CreateMap<TermPaperModelMapper, TermPaper>()
                .ForMember(tp => tp.DateBegin, tp => tp.MapFrom(model => model.DateBegin))
                .ForMember(tp => tp.DateEnd, tp => tp.MapFrom(model => model.DateEnd))
                .ForMember(tp => tp.Title, tp => tp.MapFrom(model => model.Title))
                .ForMember(tp => tp.Area, tp => tp.MapFrom(model => model.Area))
                .ForMember(tp => tp.Course, tp => tp.MapFrom(model => model.Course))
                .ForMember(tp => tp.KeywordTermPapers, tp => tp.MapFrom(model => model.KeywordTermPapers))
                .ForMember(tp => tp.TermPaperAdvisors, tp => tp.MapFrom(model => model.TermPaperAdvisors));
        }
    }
}
