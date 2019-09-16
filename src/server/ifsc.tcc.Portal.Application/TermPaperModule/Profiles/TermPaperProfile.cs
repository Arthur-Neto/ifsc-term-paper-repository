using System.Linq;
using AutoMapper;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Domain.KeywordModule;
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
                .ForMember(tp => tp.StudentAName, tp => tp.MapFrom(cmd => cmd.StudentAName))
                .ForMember(tp => tp.StudentBName, tp => tp.MapFrom(cmd => cmd.StudentBName))
                .ForMember(tp => tp.AdvisorName, tp => tp.MapFrom(cmd => cmd.AdvisorName))
                .ForMember(tp => tp.CoAdvisorName, tp => tp.MapFrom(cmd => cmd.CoAdvisorName))
                .ForMember(tp => tp.AreaName, tp => tp.MapFrom(cmd => cmd.AreaName))
                .ForMember(tp => tp.CourseName, tp => tp.MapFrom(cmd => cmd.CourseName))
                .ForMember(tp => tp.TermPaperKeywords, tp => tp.MapFrom(cmd => cmd.Keywords.Select(kwd => new TermPaperKeyword(new Keyword(kwd)))));
        }
    }
}
