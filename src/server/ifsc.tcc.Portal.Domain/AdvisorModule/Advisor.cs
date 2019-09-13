using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.AdvisorModule
{
    public class Advisor : Entity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public AdvisorType AdvisorType { get; private set; }

        private Advisor()
        { }
    }
}
