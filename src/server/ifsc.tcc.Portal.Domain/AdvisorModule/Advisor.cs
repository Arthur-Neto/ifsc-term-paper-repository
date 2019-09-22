using System.Collections.Generic;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.AdvisorModule
{
    public class Advisor : Entity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        public virtual IEnumerable<TermPaperAdvisor> TermPaperAdvisors { get; private set; }

        private Advisor()
        { }

        public Advisor(string name)
        {
            Name = name;
        }

        public Advisor(string login, string password, string name) : this(login)
        {
            Password = password;
            Name = name;
        }
    }
}
