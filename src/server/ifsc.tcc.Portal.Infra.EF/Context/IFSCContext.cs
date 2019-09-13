using ifsc.tcc.Portal.Domain.AdvisorModule;
using ifsc.tcc.Portal.Domain.AreaModule;
using ifsc.tcc.Portal.Domain.CourseModule;
using ifsc.tcc.Portal.Domain.KeywordModule;
using ifsc.tcc.Portal.Domain.StudentModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Context
{
    public class IFSCContext : DbContext
    {
        public IFSCContext(DbContextOptions<IFSCContext> options)
            : base(options)
        { }

        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<KeywordTermPaper> KeywordsTermPapers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TermPaper> TermPapers { get; set; }
        public DbSet<TermPaperAdvisor> TermPapersAdvisors { get; set; }
        public DbSet<TermPaperFile> TermPaperFiles { get; set; }
    }
}
