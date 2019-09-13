﻿using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.StudentModule
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int TermPaperID { get; private set; }

        public virtual TermPaper TermPaper { get; private set; }

        private Student()
        { }
    }
}